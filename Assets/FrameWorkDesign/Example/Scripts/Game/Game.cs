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
            GameModel.killCount.OnValueChanged += OnKillCountChanged;
        }
        private void OnKillCountChanged(int killCount)
        {
            if (killCount == 10)
                GamePassEvent.Trigger();
        }

        private void OnKilledEnemy()
        {
            GameModel.killCount.Value++;
        }
        private void OnGameStart()
        {
            transform.Find("Enemies").gameObject.SetActive(true);
        }
        private void OnDestroy()
        {
            GameStartEvent.UnRegister(OnGameStart);
            KilledOneEnemyEvent.UnRegister(OnKilledEnemy);
            GameModel.killCount.OnValueChanged -= OnKillCountChanged;
        }
    }
}