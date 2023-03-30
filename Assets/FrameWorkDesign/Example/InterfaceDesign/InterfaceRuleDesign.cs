using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class InterfaceRuleDesign : MonoBehaviour
    {
        public class OnlyCanDo1 : ICanDo1
        {
            CanDoEverything IHasEverything.doEverything { get; } = new CanDoEverything();
        }

        private void Start()
        {
            OnlyCanDo1 ocd = new OnlyCanDo1();
            //ocd.DS1();
        }

    }
    public class CanDoEverything
    {
        public void DS1()
        {
            Debug.Log("DS1");
        }
        public void DS2()
        {
            Debug.Log("DS2");
        }
    }
    public interface IHasEverything
    {
        public CanDoEverything doEverything { get; }
    }
    public interface ICanDo1 : IHasEverything
    {

    }
    public interface ICanDo2 : IHasEverything
    {

    }
    public static class ICanDo1Extension1
    {
        public static void DoSomething1(ICanDo1 self)
        {
            self.doEverything.DS1();
        }
    }

}
