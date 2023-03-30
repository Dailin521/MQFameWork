namespace FrameWorkDesign.Example
{
    public interface IGameModel : IModel
    {
        BindableProperty<int> killCount { get; }
    }
    public class GameModel : IGameModel
    {
        public BindableProperty<int> killCount { get; } = new BindableProperty<int>()
        {
            Value = 0
        };
        public IArchitecture Architecture { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Init()
        {

        }
    }
}
