using System.Threading.Tasks;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.Features.RealtimeLocation
{
    public class OpenLocationEditPopupCommand : AAsyncCommand
    {
        [Inject] NavigationManager navigationManager;
        
        protected override async Task DoRun()
        {
            var editPopupRoot = await navigationManager.OpenScene<LocationEditPopupRoot>(SceneId.LocationEditPopup, LoadSceneMode.Additive);
            
        }
    }
}