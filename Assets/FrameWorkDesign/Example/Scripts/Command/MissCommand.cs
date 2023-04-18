namespace FrameWorkDesign.Example
{
    public class MissCommand : AbstractCommand
    {
        protected override void OnExcute()
        {
            this.SendEvent<OnMissEvent>();
        }
    }
}
