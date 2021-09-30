using System.Threading.Tasks;
using GameCreator.Config;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.SceneManagement
{
    public class SceneLoader
    {
        [Inject] ZenjectSceneLoader zenjectSceneLoader;
        [Inject] ScenesConfig scenesConfig;

        public void LoadScene(SceneId sceneId, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            var sceneName = scenesConfig.GetSceneName(sceneId);
            LoadScene(sceneName, loadMode);
        }

        public void LoadScene(string name, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            zenjectSceneLoader.LoadScene(name, loadMode);
        }

        public async Task LoadSceneAsync(SceneId sceneId, LoadSceneMode loadMode = LoadSceneMode.Single,
            bool allowActivation = true)
        {
            var sceneName = scenesConfig.GetSceneName(sceneId);
            await LoadSceneAsync(sceneName, loadMode, allowActivation);
        }

        public async Task LoadSceneAsync(string sceneName, LoadSceneMode loadMode = LoadSceneMode.Single,
            bool allowActivation = true)
        {
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName, loadMode);
            asyncOperation.allowSceneActivation = allowActivation;

            while (!asyncOperation.isDone)
            {
                await Task.Yield();
            }
        }

        public void Unload(SceneId sceneId)
        {
            var sceneName = scenesConfig.GetSceneName(sceneId);
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}