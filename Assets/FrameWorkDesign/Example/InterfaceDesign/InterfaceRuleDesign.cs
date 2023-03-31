using UnityEngine;

namespace FrameWorkDesign.Example
{
    public class InterfaceRuleDesign : MonoBehaviour
    {
        public class OnlyCanDo1 : ICanDo1
        {
            CanDoEverything IHasEverything.canDoEverything { get; } = new CanDoEverything();
        }
        public class OnlyCanDo2 : ICanDo1, ICanDo2
        {
            CanDoEverything IHasEverything.canDoEverything { get; } = new CanDoEverything();
        }

        private void Start()
        {
            OnlyCanDo1 ocd = new OnlyCanDo1();
            OnlyCanDo2 ocd2 = new OnlyCanDo2();
            ocd.DoSomething1();

            ocd2.DoSomething2();
            ocd2.DoSomething1();
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
        public CanDoEverything canDoEverything { get; }
    }
    public interface ICanDo1 : IHasEverything
    {

    }
    public interface ICanDo2 : IHasEverything
    {

    }
    public static class ICanDo1Extension1
    {
        public static void DoSomething1(this ICanDo1 self)
        {
            self.canDoEverything.DS1();
        }
        public static void DoSomething2(this ICanDo2 self)
        {
            self.canDoEverything.DS2();
        }
    }

}
