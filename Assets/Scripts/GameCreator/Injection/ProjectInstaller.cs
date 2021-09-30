using GameCreator.SceneManagement;
using UnityEngine;
using Zenject;

namespace GameCreator.Injection
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("[ProjectInstaller] Installing bindings");
            Container.Bind<SceneLoader>().AsSingle();

            BindCommands();
        }

        void BindCommands()
        {
            Container.Bind<LoadSceneCommand>().AsSingle();
        }
    }
}