using UnityEngine;
namespace FrameWorkDesign.Example
{
    public interface IScoreSystem : ISystem
    {

    }
    public class ScoreSystem : AbstractSystem, IScoreSystem
    {
        protected override void OnInit()
        {
            var gameModel = this.GetModel<IGameModel>();
            this.RegisterEvent<GamePassEvent>(e =>
            {
                gameModel.Score.Value = Random.Range(1, 50);
                Debug.Log("Score：" + gameModel.Score.Value);
                Debug.Log("BestScore：" + gameModel.BestScore.Value);
                if (gameModel.Score.Value > gameModel.BestScore.Value)
                {
                    Debug.Log("成就刷新");
                    gameModel.BestScore.Value = gameModel.Score.Value;
                }
            });
        }
    }

}
