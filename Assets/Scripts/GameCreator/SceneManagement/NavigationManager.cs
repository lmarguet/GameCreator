using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.SceneManagement
{
    public class NavigationManager
    {
        [Inject] SceneLoader sceneLoader;

        readonly Dictionary<ASceneRoot, SceneId> scenes = new Dictionary<ASceneRoot, SceneId>();

        public async Task<T> OpenScene<T>(SceneId sceneId, LoadSceneMode loadSceneMode) where T : ASceneRoot
        {
            var scene = await LoadScene<T>(sceneId, loadSceneMode);

            var rootGameObjects = scene.GetRootGameObjects();
            if (rootGameObjects.Length > 1)
            {
                throw new Exception($"Scene {scene.name} has more than 1 root object");
            }

            var sceneRoot = rootGameObjects.First().GetComponent<T>();

            if (scenes.ContainsKey(sceneRoot))
            {
                throw new Exception($"Scene {scene.name} is already loaded");
            }

            scenes.Add(sceneRoot, sceneId);
            return sceneRoot;
        }

        async Task<Scene> LoadScene<T>(SceneId sceneId, LoadSceneMode loadSceneMode) where T : ASceneRoot
        {
            var sceneIndex = GetNewSceneIndex(loadSceneMode);
            await sceneLoader.LoadSceneAsync(sceneId, loadSceneMode);
            var scene = SceneManager.GetSceneAt(sceneIndex);
            return scene;
        }

        static int GetNewSceneIndex(LoadSceneMode loadMode)
        {
            return loadMode == LoadSceneMode.Additive
                ? SceneManager.sceneCount
                : SceneManager.sceneCount - 1;
        }

        public T GetScene<T>() where T : ASceneRoot
        {
            return scenes.First(x => x.Key is T).Key as T;
        }

        public void CloseScene<T>() where T : ASceneRoot
        {
            var root = GetScene<T>();
            var sceneId = scenes[root];
            scenes.Remove(root);
            sceneLoader.Unload(sceneId);
        }

        public void CloseScene(SceneId sceneId)
        {
            var sceneEntry = scenes.First(x => x.Value == sceneId);
            scenes.Remove(sceneEntry.Key);
            sceneLoader.Unload(sceneId);
            
        }
    }
}