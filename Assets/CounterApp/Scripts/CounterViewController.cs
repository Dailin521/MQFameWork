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
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(delegate
            {
                CountModel.Count++;
                UpdateView();
            });
            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(delegate
            {
                CountModel.Count--;
                UpdateView();
            });
        }
        void UpdateView()
        {
            transform.Find("CountText").GetComponent<TMP_Text>().text = CountModel.Count.ToString();
        }
        public static class CountModel
        {
            public static int Count = 0;
        }

    }
}
