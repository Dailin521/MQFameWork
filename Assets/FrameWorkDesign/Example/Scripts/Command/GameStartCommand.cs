namespace FrameWorkDesign.Example
{
    public class GameStartCommand : ICommand
    {
        public void Excute()
        {
            GameStartEvent.Trigger();
        }

    }
}
