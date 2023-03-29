using FrameWorkDesign;

namespace CounterApp
{
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            Register(new CountModel());
            //Debug.Log("已注册");
        }
    }
}
