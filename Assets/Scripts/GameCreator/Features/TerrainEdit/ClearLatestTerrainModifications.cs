using GameCreator.Features.GameScene;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using Zenject;

namespace GameCreator.Features.TerrainEdit
{
    public class ClearLatestTerrainModifications : ACommand
    {
        [Inject] NavigationManager navigationManager;

        public override void Execute()
        {
            var sceneRoot = navigationManager.GetScene<GameSceneRoot>();
            sceneRoot.ClearLatestTerrainModifications();
        }
    }
}