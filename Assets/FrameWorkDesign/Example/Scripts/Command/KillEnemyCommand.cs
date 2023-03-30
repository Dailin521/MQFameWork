using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class KillEnemyCommand : ICommand
    {
        public void Excute()
        {
            var gameModel = PointGame.Get<IGameModel>();
            gameModel.killCount.Value++;
            if (gameModel.killCount.Value == 10)
            {
                GamePassEvent.Trigger();
            }
        }
    }
}
