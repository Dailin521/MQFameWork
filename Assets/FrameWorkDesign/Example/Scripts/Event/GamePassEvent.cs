using System;
namespace FrameWorkDesign.Example
{
    public class GamePassEvent
    {
        private static Action mAction;
        public static void Register(Action action)
        {
            mAction += action;
        }
        public static void UnRegister(Action action)
        {
            mAction -= action;
        }
        public static void Trigger()
        {
            mAction?.Invoke();
        }
    }
}