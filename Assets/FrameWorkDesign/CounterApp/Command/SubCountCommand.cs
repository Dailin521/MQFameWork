using FrameWorkDesign;
namespace CounterApp
{
    public class SubCountCommand : AbstractCommand
    {
        protected override void OnExcute()
        {
            this.GetModel<ICountModel>().Count.Value--;
        }
    }
}
