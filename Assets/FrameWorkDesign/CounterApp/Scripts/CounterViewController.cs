using FrameWorkDesign;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        private CountModel mCountModel;
        void Start()
        {
            mCountModel = CounterApp.Get<CountModel>();
            mCountModel.Count.OnValueChanged += OnCountChanged;
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(delegate
            {
                new AddCountCommand().Excute();
                Debug.Log(CounterApp.Get<CountModel>().Count.Value);
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
    public class CountModel
    {
        public BindableProperty<int> Count = new()
        {
            Value = 0,
        };
    }
}
