namespace FrameWorkDesign
{
    public interface IController : IBelongToArchitecture, ICanSendCommand, ICanGetModel, ICanGetSystem, ICanRegisterEvent
    {

    }
}
