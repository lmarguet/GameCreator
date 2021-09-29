using System.Threading.Tasks;
using GameCreator.Framework;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.SceneManagement
{
    public class LoadSceneCommand : AAsyncCommand<LoadSceneCommand.Data>
    {
        public struct Data
        {
            public Scene Scene;
            public LoadSceneMode LoadMode;
        }

        [Inject] private SceneLoader sceneLoader;

        protected override async Task DoRun(Data data)
        {
            await sceneLoader.LoadSceneAsync(data.Scene, data.LoadMode);
        }
    }
}