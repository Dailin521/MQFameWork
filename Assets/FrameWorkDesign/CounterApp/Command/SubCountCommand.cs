using FrameWorkDesign;
namespace CounterApp
{
    public class SubCountCommand : AbstractCommand
    {
        protected override void OnExcute()
        {
            GetArchitecture().GetModel<ICountModel>().Count.Value--;
        }
    }
}
