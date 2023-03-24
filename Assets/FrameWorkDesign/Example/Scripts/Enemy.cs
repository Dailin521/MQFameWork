using UnityEngine;
namespace FrameWorkDesign.Example
{
    public class Enemy : MonoBehaviour
    {
        public GameObject GamePassPanel;
        static int mKilledEnemyCount = 0;
        public void OnMouseDown()
        {
            Destroy(gameObject);
            mKilledEnemyCount++;
            if (mKilledEnemyCount == 10)
                GamePassPanel.SetActive(true);
        }
    }
}