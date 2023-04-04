using UnityEngine;
namespace FrameWorkDesign.Example
{
    public class Enemy : MonoBehaviour, IController
    {
        public GameObject GamePassPanel;

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return PointGame.Interface;
        }

        public void OnMouseDown()
        {
            Destroy(gameObject);
            this.SendCommand(new KillEnemyCommand());
        }
    }
}