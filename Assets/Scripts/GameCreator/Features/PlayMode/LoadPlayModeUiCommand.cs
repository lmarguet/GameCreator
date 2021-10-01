using System.Threading.Tasks;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.Features.PlayMode
{
    public class LoadPlayModeUiCommand : AAsyncCommand
    {
        [Inject] NavigationManager navigationManager;

        protected override async Task DoRun()
        {
            await navigationManager.OpenScene<PlayModeUiRoot>(SceneId.PlayModeUi, LoadSceneMode.Additive);
        }
    }
}