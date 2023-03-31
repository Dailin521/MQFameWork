namespace FrameWorkDesign
{
    public interface ISystem : IBelongToArchitecture, ICanSetArchitecture
    {
        void Init();
    }
    public abstract class AbstractSystem : ISystem
    {
        private IArchitecture mArchitecture;
        public IArchitecture GetArchitecture()
        {
            return mArchitecture;
        }

        void ISystem.Init()
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
