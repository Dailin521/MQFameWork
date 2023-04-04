namespace FrameWorkDesign.Example
{
    public class GameStartCommand : AbstractCommand
    {
        protected override void OnExcute()
        {
            this.SendEvent<GameStartEvent>();

        }
    }
}
