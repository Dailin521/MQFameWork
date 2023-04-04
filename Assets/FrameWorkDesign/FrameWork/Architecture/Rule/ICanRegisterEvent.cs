using System;

namespace FrameWorkDesign
{
    public interface ICanRegisterEvent : IBelongToArchitecture
    {

    }
    public static class CanRegisterEventExtension
    {
        public static IUnRegister RegisterEvent<T>(this ICanRegisterEvent self, Action<T> e)
        {
            return self.GetArchitecture().RegisterEvent<T>(e);
        }
        public static void UnRegisterEvent<T>(this ICanRegisterEvent self, Action<T> e)
        {
            self.GetArchitecture().UnRegisterEvent<T>(e);
        }
    }
}
