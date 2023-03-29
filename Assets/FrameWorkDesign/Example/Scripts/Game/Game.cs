using System;
using UnityEngine;
namespace FrameWorkDesign.Example
{
    public class Game : MonoBehaviour
    {
        private void Awake()
        {
            GameStartEvent.Register(OnGameStart);
            KilledOneEnemyEvent.Register(OnKilledEnemy);
        }
        private void OnKilledEnemy()
        {
            GameModel.killCount++;
            if (GameModel.killCount == 10)
                GamePassEvent.Trigger();
        }
        private void OnGameStart()
        {
            transform.Find("Enemies").gameObject.SetActive(true);
        }
        private void OnDestroy()
        {
            GameStartEvent.UnRegister(OnGameStart);
            KilledOneEnemyEvent.UnRegister(OnKilledEnemy);
        }
    }
}