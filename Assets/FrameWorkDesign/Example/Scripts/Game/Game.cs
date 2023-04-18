using System;
using UnityEngine;
namespace FrameWorkDesign.Example
{
    public class Game : MonoBehaviour, IController
    {
        private void Awake()
        {
            this.RegisterEvent<GameStartEvent>(OnGameStart).UnRegisterWhenGameObjDestroyed(gameObject);
        }
        private void OnGameStart(GameStartEvent e)
        {
            transform.Find("Enemies").gameObject.SetActive(true);
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.Interface;
        }
    }
}