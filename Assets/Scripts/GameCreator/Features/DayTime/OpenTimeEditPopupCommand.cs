using System.Threading.Tasks;
using GameCreator.Features.GameScene;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.Features.DayTime
{
    public class OpenTimeEditPopupCommand : AAsyncCommand
    {
        [Inject] NavigationManager navigationManager;
        
        protected override async Task DoRun()
        {
            var gameSceneRoot = navigationManager.GetScene<GameSceneRoot>();
            
            var editPopupRoot = await navigationManager.OpenScene<TimeEditPopupRoot>(SceneId.LocationEditPopup, LoadSceneMode.Additive);
            editPopupRoot.SetCurrenTimeData(gameSceneRoot.SceneTime);
            
        }
    }
}