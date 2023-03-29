using FrameWorkDesign;
namespace CounterApp
{
    public class SubCountCommand : ICommand
    {
        public void Excute()
        {
            CountModel.Instance.Count.Value--;
        }
    }
}
