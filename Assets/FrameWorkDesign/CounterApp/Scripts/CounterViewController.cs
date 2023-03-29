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
            CountModel.Count.OnValueChanged += OnCountChanged;
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(delegate
            {
                CountModel.Count.Value++;

            });
            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(delegate
            {
                CountModel.Count.Value--;

            });
        }
        private void OnCountChanged(int obj)
        {
            transform.Find("CountText").GetComponent<TMP_Text>().text = obj.ToString();
        }
        private void OnDestroy()
        {
            CountModel.Count.OnValueChanged -= OnCountChanged;
        }
        public static class CountModel
        {
            public static BindableProperty<int> Count = new BindableProperty<int>()
            {
                Value = 0,
            };
        }
    }
}
