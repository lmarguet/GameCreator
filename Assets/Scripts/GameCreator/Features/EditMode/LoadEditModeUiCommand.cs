using System.Threading.Tasks;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.Features.EditMode
{
    public class LoadEditModeUiCommand : AAsyncCommand
    {
        [Inject] NavigationManager navigationManager;

        protected override async Task DoRun()
        {
            await navigationManager.OpenScene<EditModeUiRoot>(SceneId.EditModeUi, LoadSceneMode.Additive);
        }
    }
}