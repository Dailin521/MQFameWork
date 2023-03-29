using FrameWorkDesign;
namespace CounterApp
{
    public struct AddCountCommand : ICommand
    {
        public void Excute()
        {
            CountModel.Instance.Count.Value++;
        }
    }
}
