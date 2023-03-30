using FrameWorkDesign;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        private ICountModel mCountModel;
        CountModel2 mc2;
        void Start()
        {
            mCountModel = CounterApp.Get<ICountModel>();
            mCountModel.Count.OnValueChanged += OnCountChanged;
            mCountModel.Count.OnValueChanged?.Invoke(mCountModel.Count.Value);
            mCountModel.Architecture.RegisterModel<CountModel2>(new CountModel2());
            mc2 = CounterApp.Get<CountModel2>();
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(delegate
            {
                new AddCountCommand().Excute();
                mc2.Count2.Value++;
                Debug.Log(mc2.Count2.Value);
            });
            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(delegate
            {
                new SubCountCommand().Excute();
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
    }
    public interface ICountModel : IModel
    {
        public BindableProperty<int> Count { get; }//只读的获取，修改在内部的Value
    }
    public class CountModel : ICountModel
    {
        public void Init()
        {
            var storage = Architecture.GetUtility<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);
            Count.OnValueChanged += c => { storage.SaveInt("COUNTER_COUNT", c); };
        }
        public BindableProperty<int> Count { get; } = new()
        {
            Value = 0,
        };
        public IArchitecture Architecture { get; set; }
    }
    public class CountModel2 : IModel
    {
        public IArchitecture Architecture { get; set; }

        public void Init()
        {

        }
        public BindableProperty<int> Count2 { get; } = new()
        {
            Value = 0,
        };
    }
}
