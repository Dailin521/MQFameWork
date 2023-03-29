using UnityEngine;
namespace FrameWorkDesign.Example
{
    public class Enemy : MonoBehaviour
    {
        public GameObject GamePassPanel;

        public void OnMouseDown()
        {
            Destroy(gameObject);
            new KillEnemyCommand().Excute();
        }
    }
}