using System.Threading.Tasks;
using GameCreator.Features.GameScene;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.Features.EditModeUi
{
    public class LoadEditModeCommand : AAsyncCommand
    {
        [Inject] NavigationManager navigationManager;

        protected override async Task DoRun()
        {
            await navigationManager.OpenScene<EditModeUiRoot>(SceneId.EditModeUi, LoadSceneMode.Additive);

            var gameSceneRoot = navigationManager.GetScene<GameSceneRoot>();
            gameSceneRoot.EnterEditMode();
            gameSceneRoot.ResetObjectStates();
        }
    }
}