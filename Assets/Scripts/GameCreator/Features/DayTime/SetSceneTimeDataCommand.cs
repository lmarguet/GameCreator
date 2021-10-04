using GameCreator.Features.GameScene;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using Zenject;

namespace GameCreator.Features.DayTime
{
    public class SetSceneTimeDataCommand : ACommand<GameSceneRoot.SceneTimeData>
    {
        
        [Inject] NavigationManager navigationManager;
        
        public override void Execute(GameSceneRoot.SceneTimeData data)
        {
            var gameSceneRoot = navigationManager.GetScene<GameSceneRoot>();
            gameSceneRoot.SetSceneTime(data);
        }
    }
}