using GameCreator.Framework;
using GameCreator.SceneManagement;
using UnityEngine;
using Zenject;

namespace GameCreator.Bootstrap
{
    public class BoostrapRoot : ASceneRoot
    {
        [Inject] private SceneLoader sceneLoader;
        
        private async void Start()
        {
            Debug.Log("[BoostrapRoot] Start");
            
            await sceneLoader.LoadSceneAsync(Scene.Start);
        }
    }
}
