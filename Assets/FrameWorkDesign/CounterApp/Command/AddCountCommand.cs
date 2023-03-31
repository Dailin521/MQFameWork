using FrameWorkDesign;
using UnityEngine;
namespace CounterApp
{
    public class AddCountCommand : AbstractCommand
    {
        protected override void OnExcute()
        {
            GetArchitecture().GetModel<ICountModel>().Count.Value++;
        }
    }
}
