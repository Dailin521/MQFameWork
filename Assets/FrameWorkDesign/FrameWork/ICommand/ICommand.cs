namespace FrameWorkDesign
{
    public interface ICommand : IBelongToArchitecture, ICanSetArchitecture, ICanGetModel, ICanGetUtility, ICanGetSystem, ICanSendEvent, ICanSendCommand
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
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return mArchitecture;
        }
        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }
        protected abstract void OnExcute();
    }
}
