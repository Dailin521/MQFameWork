using FrameWorkDesign;
using UnityEngine;

namespace CounterApp
{
    public interface IAchievementSystem : ISystem
    {

    }
    public class AchievementSystem : AbstractSystem, IAchievementSystem
    {
        protected override void OnInit()
        {
            var countModel = this.GetModel<ICountModel>();
            var previousCount = countModel.Count.Value;
            countModel.Count.OnValueChanged += newCount =>
            {
                if (previousCount < 10 && newCount >= 10)
                {
                    Debug.Log("解锁10击成就");
                }
                else if (previousCount < 20 && newCount >= 20)
                {
                    Debug.Log("解锁20击成就");
                }
                previousCount = newCount;
            };
        }
    }
}
