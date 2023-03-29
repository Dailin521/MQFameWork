using FrameWorkDesign;
using UnityEngine;
namespace CounterApp
{
    public struct AddCountCommand : ICommand
    {
        public void Excute()
        {
            CounterApp.Get<CountModel>()
            .Count.Value++;
        }
    }
}
