using GameCreator.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Scene = GameCreator.SceneManagement.Scene;

namespace GameCreator.Bootstrap
{
    public class BoostrapRoot : ASceneRoot
    {
        [Inject] LoadSceneCommand loadSceneCommand;

        async void Start()
        {
            Debug.Log("[BoostrapRoot] Start");
            await loadSceneCommand.Run(new LoadSceneCommand.Data
            {
                Scene = Scene.Start,
                LoadMode = LoadSceneMode.Single
            });
        }
    }
}