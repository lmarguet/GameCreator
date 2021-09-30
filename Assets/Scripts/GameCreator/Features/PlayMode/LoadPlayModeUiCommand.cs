using System.Threading.Tasks;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.Features.PlayMode
{
    public class LoadPlayModeUiCommand : AAsyncCommand
    {
        [Inject] LoadSceneCommand loadSceneCommand;

        protected override async Task DoRun()
        {
            await loadSceneCommand.Run(new LoadSceneCommand.Data
            {
                SceneId = SceneId.PlayModeUi,
                LoadMode = LoadSceneMode.Additive
            }); 
        }
    }
}