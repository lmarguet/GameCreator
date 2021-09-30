using System.Threading.Tasks;
using GameCreator.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.SceneManagement
{
    public class LoadSceneCommand : AAsyncCommand<LoadSceneCommand.Data, Scene>
    {
        public struct Data
        {
            public SceneId SceneId;
            public LoadSceneMode LoadMode;
        }

        [Inject] SceneLoader sceneLoader;

        protected override async Task<Scene> DoRun(Data data)
        {
            Debug.Log($"[LoadSceneCommand] {data.SceneId}");

            var sceneIndex = GetNewSceneIndex(data);

            await sceneLoader.LoadSceneAsync(data.SceneId, data.LoadMode);

            return SceneManager.GetSceneAt(sceneIndex);
        }

        static int GetNewSceneIndex(Data data)
        {
            return data.LoadMode == LoadSceneMode.Additive
                ? SceneManager.sceneCount
                : SceneManager.sceneCount - 1;
        }
    }
}