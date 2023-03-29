using FrameWorkDesign;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            CountModel.Instance.Count.OnValueChanged += OnCountChanged;
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
            CountModel.Instance.Count.OnValueChanged -= OnCountChanged;
        }
    }
    public class CountModel : Singleton<CountModel>
    {
        private CountModel() { }
        public BindableProperty<int> Count = new BindableProperty<int>()
        {
            Value = 0,
        };
    }
}
