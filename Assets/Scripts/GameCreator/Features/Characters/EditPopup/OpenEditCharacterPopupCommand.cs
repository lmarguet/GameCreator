using System.Threading.Tasks;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.Features.Characters.EditPopup
{
    public class OpenEditCharacterPopupCommand : AAsyncCommand
    {
        [Inject] NavigationManager navigationManager;
        
        protected override async Task DoRun()
        {
            var editPopupRoot = await navigationManager.OpenScene<CharacterEditPopupRoot>(SceneId.CharacterEditPopup, LoadSceneMode.Additive);
            
            // TODO setup
        }
    }
}