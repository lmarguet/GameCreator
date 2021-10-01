using GameCreator.Features.StartScreen;
using GameCreator.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameCreator.Bootstrap
{
    public class BoostrapRoot : ASceneRoot
    {
        [Inject] NavigationManager navigationManager;

        async void Start()
        {
            Debug.Log("[BoostrapRoot] Start");

            await navigationManager.OpenScene<StartScreenRoot>(SceneId.Start, LoadSceneMode.Single);
        }
    }
}