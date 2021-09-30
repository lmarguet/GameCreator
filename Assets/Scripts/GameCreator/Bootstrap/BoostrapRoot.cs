using GameCreator.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

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
                SceneId = SceneId.Start,
                LoadMode = LoadSceneMode.Single
            });
        }
    }
}