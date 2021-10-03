using GameCreator.Features.EditModeUi;
using GameCreator.Features.GameScene;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using Zenject;

namespace GameCreator.Features.TerrainEdit
{
    public class ExitTerrainEditStateCommand : ACommand
    {
        [Inject] NavigationManager navigationManager;

        public override void Execute()
        {
            var gameSceneRoot = navigationManager.GetScene<GameSceneRoot>();
            gameSceneRoot.StopEditingTerrain();
            
            var editModeUiRoot = navigationManager.GetScene<EditModeUiRoot>();
            editModeUiRoot.CloseToolBar();
            
        }
    }
}