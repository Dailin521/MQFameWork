namespace FrameWorkDesign.Example
{
    public class GameModel : Singleton<GameModel>
    {
        private GameModel() { }
        public BindableProperty<int> killCount = new BindableProperty<int>()
        {
            Value = 0
        };
    };

}
