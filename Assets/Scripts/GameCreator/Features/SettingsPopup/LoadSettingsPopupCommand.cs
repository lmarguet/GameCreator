using System.Threading.Tasks;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.Features.SettingsPopup
{
    public class LoadSettingsPopupCommand : AAsyncCommand
    {
        [Inject] NavigationManager navigationManager;
        
        protected override async Task DoRun()
        {
            await navigationManager.OpenScene<SettingsPopupRoot>(SceneId.SettingsPopup, LoadSceneMode.Additive);
        }
    }
}