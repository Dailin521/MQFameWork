using FrameWorkDesign;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        private ICountModel mCountModel;
        void Start()
        {
            mCountModel = CounterApp.Get<ICountModel>();
            mCountModel.Count.OnValueChanged += OnCountChanged;
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(delegate
            {
                new AddCountCommand().Excute();
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
        }
    }
    public interface ICountModel
    {
        public BindableProperty<int> Count { get; }
    }
    public class CountModel : ICountModel
    {
        public BindableProperty<int> Count { get; } = new()
        {
            Value = 0,
        };
    }
}
