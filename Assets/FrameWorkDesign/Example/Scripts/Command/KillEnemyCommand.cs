using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class KillEnemyCommand : ICommand
    {
        public void Excute()
        {
            GameModel.Instance.killCount.Value++;
            if (GameModel.Instance.killCount.Value == 10)
            {
                GamePassEvent.Trigger();
            }
        }
    }
}
