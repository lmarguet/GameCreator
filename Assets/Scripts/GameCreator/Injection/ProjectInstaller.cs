using GameCreator.Features.EditMode;
using GameCreator.Features.GameScene;
using GameCreator.Features.PlayMode;
using GameCreator.Features.SettingsPopup;
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
            Container.Bind<NavigationManager>().AsSingle();

            BindCommands();
        }

        void BindCommands()
        {
            // Scenes command
            Container.Bind<LoadGameSceneCommand>().AsSingle();
            Container.Bind<LoadEditModeUiCommand>().AsSingle();
            Container.Bind<LoadSettingsPopupCommand>().AsSingle();
            Container.Bind<LoadPlayModeUiCommand>().AsSingle();
        }
    }
}