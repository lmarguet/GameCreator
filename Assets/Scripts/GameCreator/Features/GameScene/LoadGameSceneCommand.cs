using System.Threading.Tasks;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.Features.GameScene
{
    public class LoadGameSceneCommand : AAsyncCommand
    {
        [Inject] NavigationManager navigationManager;

        protected override async Task DoRun()
        {
            await navigationManager.OpenScene<GameSceneRoot>(SceneId.Game, LoadSceneMode.Single);
        }
    }
}