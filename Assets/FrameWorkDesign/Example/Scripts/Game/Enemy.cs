using UnityEngine;
namespace FrameWorkDesign.Example
{
    public class Enemy : MonoBehaviour, IController
    {
        public GameObject GamePassPanel;

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }

        public void OnMouseDown()
        {
            Destroy(gameObject);
            GetArchitecture().SendCommand(new KillEnemyCommand());
        }
    }
}