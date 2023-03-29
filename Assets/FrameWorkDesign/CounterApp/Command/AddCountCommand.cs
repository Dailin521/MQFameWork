using FrameWorkDesign;
namespace CounterApp
{
    public struct AddCountCommand : ICommand
    {
        public void Excute()
        {
            CountModel.Count.Value++;
        }
    }
}
