using UnityEngine;
using UnityEngine.UI;

namespace FrameWorkDesign.Example
{
    public class GameStartPanel : MonoBehaviour
    {
        public GameObject Enemys;
        private void Start()
        {
            transform.Find("btnStart").GetComponent<Button>().onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                new GameStartCommand().Excute();
            });
        }
    }
}