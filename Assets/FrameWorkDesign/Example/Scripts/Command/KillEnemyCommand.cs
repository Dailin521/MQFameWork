using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class KillEnemyCommand : AbstractCommand
    {
        protected override void OnExcute()
        {
            var gameModel = this.GetModel<IGameModel>();
            gameModel.KillCount.Value++;
            this.SendEvent<OnEnemyKillEvent>();
            if (gameModel.KillCount.Value == 10)
            {
                this.SendEvent<GamePassEvent>();
            }
        }
    }
}
