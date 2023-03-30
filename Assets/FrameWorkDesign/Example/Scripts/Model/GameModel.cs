namespace FrameWorkDesign.Example
{
    public interface IGameModel
    {
        BindableProperty<int> killCount { get; }
    }
    public class GameModel : IGameModel
    {
        public BindableProperty<int> killCount { get; } = new BindableProperty<int>()
        {
            Value = 0
        };
    };

}
