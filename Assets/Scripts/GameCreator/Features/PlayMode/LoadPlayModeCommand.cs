using System.Threading.Tasks;
using GameCreator.Features.Characters;
using GameCreator.Features.GameScene;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.Features.PlayMode
{
    public class LoadPlayModeCommand : AAsyncCommand
    {
        [Inject] NavigationManager navigationManager;
        [Inject] StopCharacterPlacementCommand stopCharacterPlacementCommand;

        protected override async Task DoRun()
        {
            stopCharacterPlacementCommand.Execute();
            var playModeUiRoot = await navigationManager.OpenScene<PlayModeUiRoot>(SceneId.PlayModeUi, LoadSceneMode.Additive);

            var gameSceneRoot = navigationManager.GetScene<GameSceneRoot>();
            gameSceneRoot.SaveObjectStates();
            gameSceneRoot.EnterPlayMode();

            playModeUiRoot.ShowJoystick(gameSceneRoot.HasPlayableCharacter());
        }
    }
}