namespace FrameWorkDesign
{
    public interface ICommand : IBelongToArchitecture, ICanSetArchitecture
    {
        void Excute();
    }
    public abstract class AbstractCommand : ICommand
    {
        private IArchitecture mArchitecture;
        void ICommand.Excute()
        {
            OnExcute();
        }

        public IArchitecture GetArchitecture()
        {
            return mArchitecture;
        }

        public void SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }
        protected abstract void OnExcute();
    }
}
