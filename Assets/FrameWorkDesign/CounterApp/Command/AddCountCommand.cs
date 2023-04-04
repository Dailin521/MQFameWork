using FrameWorkDesign;
using UnityEngine;
namespace CounterApp
{
    public class AddCountCommand : AbstractCommand
    {
        protected override void OnExcute()
        {
            this.GetModel<ICountModel>().Count.Value++;
        }
    }
}
