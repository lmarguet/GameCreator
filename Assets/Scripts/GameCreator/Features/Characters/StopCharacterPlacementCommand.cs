using GameCreator.Features.EditMode;
using GameCreator.Features.GameScene;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using Zenject;

namespace GameCreator.Features.Characters
{
    public class StopCharacterPlacementCommand : ACommand
    {
        [Inject] NavigationManager navigationManager;

        public override void Execute()
        {
            var gameSceneRoot = navigationManager.GetScene<GameSceneRoot>();
            gameSceneRoot.StopCharacterPlacement();

            var editSceneRoot = navigationManager.GetScene<EditModeUiRoot>();
            editSceneRoot.DeselectCharacters();
        }
    }
}