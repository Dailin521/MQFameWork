using FrameWorkDesign;
namespace CounterApp
{
    public class SubCountCommand : ICommand
    {
        public void Excute()
        {
            CounterApp.Get<CountModel>()
            .Count.Value--;
        }
    }
}
