using UnityEngine;
using UnityEngine.UI;

namespace FrameWorkDesign.Example
{
    public class GameStartPanel : MonoBehaviour, IController
    {
        //敌人
        public GameObject Enemys;

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return PointGame.Interface;
        }
        private void Start()
        {
            transform.Find("btnStart").GetComponent<Button>().onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
                this.SendCommand(new GameStartCommand());
                new TestPointCommand1().Execute();
                new TestPointCommand2().Execute();
            });
        }
    }
}