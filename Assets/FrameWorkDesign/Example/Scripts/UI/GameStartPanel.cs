using UnityEngine;
using UnityEngine.UI;

namespace FrameWorkDesign.Example
{
    public class GameStartPanel : MonoBehaviour, IController
    {
        public GameObject Enemys;

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void Start()
        {
            transform.Find("btnStart").GetComponent<Button>().onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                GetArchitecture().SendCommand(new GameStartCommand());
            });
        }
    }
}