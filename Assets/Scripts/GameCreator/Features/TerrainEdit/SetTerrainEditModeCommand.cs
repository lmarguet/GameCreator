using GameCreator.Features.GameScene;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using Zenject;

namespace GameCreator.Features.TerrainEdit
{
    public class SetTerrainEditModeCommand : ACommand<TerrainEditMode>
    {
        [Inject] NavigationManager navigationManager;
        
        public override void Execute(TerrainEditMode terrainEditMode)
        {
            var sceneRoot = navigationManager.GetScene<GameSceneRoot>();
            sceneRoot.SetTerranEditMode(terrainEditMode);
        }
    }
}