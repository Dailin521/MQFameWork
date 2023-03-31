using FrameWorkDesign;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour, IController
    {
        private ICountModel mCountModel;

        void Start()
        {
            mCountModel = GetArchitecture().GetModel<ICountModel>();
            mCountModel.Count.OnValueChanged += OnCountChanged;
            mCountModel.Count.OnValueChanged?.Invoke(mCountModel.Count.Value);
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(delegate
            {
                GetArchitecture().SendCommand(new AddCountCommand());
                //Debug.Log(mc2.Count2.Value);
            });
            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(delegate
            {
                GetArchitecture().SendCommand(new SubCountCommand());
            });
        }
        private void OnCountChanged(int obj)
        {
            transform.Find("CountText").GetComponent<TMP_Text>().text = obj.ToString();
        }
        private void OnDestroy()
        {
            mCountModel.Count.OnValueChanged -= OnCountChanged;
            mCountModel = null;
            CounterApp.OnDestroy();
        }

        public IArchitecture GetArchitecture()
        {
            return CounterApp.Interface;
        }
    }
    public interface ICountModel : IModel
    {
        public BindableProperty<int> Count { get; }//只读的获取，修改在内部的Value
    }
    public class CountModel : AbstractModel, ICountModel
    {
        protected override void OnInit()
        {
            var storage = GetArchitecture().GetUtility<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);
            Count.OnValueChanged += c => { storage.SaveInt("COUNTER_COUNT", c); };
        }
        public BindableProperty<int> Count { get; } = new()
        {
            Value = 0,
        };
    }

}
