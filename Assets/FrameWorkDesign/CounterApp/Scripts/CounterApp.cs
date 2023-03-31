using FrameWorkDesign;

namespace CounterApp
{
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            RegisterModel<ICountModel>(new CountModel());
            RegisterSystem<IAchievementSystem>(new AchievementSystem());
            RegisterUtility<IStorage>(new PlayerPrefsStorage());
            //Debug.Log("已注册");
        }
    }
}
