using System.Threading.Tasks;
using GameCreator.Features.GameScene;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.Features.PlayMode
{
    public class LoadPlayModeUiCommand : AAsyncCommand
    {
        [Inject] NavigationManager navigationManager;
        [Inject] DeselectCharacterCommand deselectCharacterCommand;

        protected override async Task DoRun()
        {
            deselectCharacterCommand.Execute();
            await navigationManager.OpenScene<PlayModeUiRoot>(SceneId.PlayModeUi, LoadSceneMode.Additive);
            
            var gameSceneRoot = navigationManager.GetScene<GameSceneRoot>();
            gameSceneRoot.EnterPlayMode();
        }
    }
}