namespace FrameWorkDesign.Example
{
    public interface IGameModel : IModel
    {
        BindableProperty<int> killCount { get; }
    }
    public class GameModel : AbstractModel, IGameModel
    {
        public BindableProperty<int> killCount { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        protected override void OnInit()
        {

        }
    }
}
