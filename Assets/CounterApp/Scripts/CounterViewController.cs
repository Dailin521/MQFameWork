using System;
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
            CountModel.OnCountChanged += OnCountChanged;
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(delegate
            {
                CountModel.Count++;

            });
            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(delegate
            {
                CountModel.Count--;

            });
        }

        private void OnCountChanged(int obj)
        {
            transform.Find("CountText").GetComponent<TMP_Text>().text = obj.ToString();
        }
        private void OnDestroy()
        {
            CountModel.OnCountChanged -= OnCountChanged;
        }
        public static class CountModel
        {
            private static int count = 0;
            public static Action<int> OnCountChanged;
            public static int Count
            {
                get => count;
                set
                {
                    if (value != count)
                    {
                        count = value;
                        OnCountChanged?.Invoke(value);
                    }
                }
            }
        }

    }
}
