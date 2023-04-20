using System;
using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class UI : MonoBehaviour, IController
    {
         IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return PointGame.Interface;
        }

        private void Awake()
        {
            this.RegisterEvent<GamePassEvent>(OnGamePass).UnRegisterWhenGameObjDestroyed(gameObject);
            //this.GetArchitecture().GetUtility
            //this.GET
        }
        private void OnGamePass(GamePassEvent e)
        {
            transform.Find("Canvas/GamePassPanel").gameObject.SetActive(true);
        }


    }
}
