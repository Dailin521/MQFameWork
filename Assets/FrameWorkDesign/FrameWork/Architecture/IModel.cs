namespace FrameWorkDesign
{
    public interface IModel : IBelongToArchitecture, ICanSetArchitecture
    {
        void Init();
    }
    public abstract class AbstractModel : IModel
    {
        private IArchitecture mArchitecture;
        public IArchitecture GetArchitecture()
        {
            return mArchitecture;
        }

        void IModel.Init()
        {
            OnInit();
        }

        public void SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }
        protected abstract void OnInit();
    }
}
