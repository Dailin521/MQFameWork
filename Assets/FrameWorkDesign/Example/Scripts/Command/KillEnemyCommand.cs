using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class KillEnemyCommand : AbstractCommand
    {
        protected override void OnExcute()
        {
            var gameModel = GetArchitecture().GetModel<IGameModel>();
            gameModel.KillCount.Value++;
            if (gameModel.KillCount.Value == 10)
            {
                GamePassEvent.Trigger();
            }
        }
    }
}
