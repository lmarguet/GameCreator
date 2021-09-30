using System.Threading.Tasks;
using GameCreator.Framework;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.SceneManagement
{
    public class LoadSceneCommand : AAsyncCommand<LoadSceneCommand.Data, UnityEngine.SceneManagement.Scene>
    {
        public struct Data
        {
            public Scene Scene;
            public LoadSceneMode LoadMode;
        }

        [Inject] private SceneLoader sceneLoader;

        protected override async Task<UnityEngine.SceneManagement.Scene> DoRun(Data data)
        {
            var sceneIndex = GetNewSceneIndex(data);

            await sceneLoader.LoadSceneAsync(data.Scene, data.LoadMode);

            return SceneManager.GetSceneAt(sceneIndex);
        }

        private static int GetNewSceneIndex(Data data)
        {
            return data.LoadMode == LoadSceneMode.Additive
                ? SceneManager.sceneCount
                : SceneManager.sceneCount - 1;
        }
    }
}