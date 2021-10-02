using GameCreator.Features.Characters;
using GameCreator.Features.Characters.EditPopup;
using GameCreator.Features.EditMode;
using GameCreator.Features.GameScene;
using GameCreator.Features.GameScene.States;
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

            Container.Bind<SceneLoader>().AsSingle().WhenInjectedInto<NavigationManager>();
            Container.Bind<NavigationManager>().AsSingle();

            BindCommands();
            BindGameSceneState();
        }

        void BindCommands()
        {
            Container.Bind<LoadGameSceneCommand>().AsSingle();
            Container.Bind<LoadEditModeUiCommand>().AsSingle();
            Container.Bind<LoadSettingsPopupCommand>().AsSingle();
            Container.Bind<LoadPlayModeUiCommand>().AsSingle();

            Container.Bind<StartCharacterPlacementCommand>().AsSingle();
            Container.Bind<StopCharacterPlacementCommand>().AsSingle();
            Container.Bind<SelectCharacterCommand>().AsSingle();
            Container.Bind<DeselectCharacterCommand>().AsSingle();

            Container.Bind<OpenEditCharacterPopupCommand>().AsSingle();
            Container.Bind<DeleteCharacterCommand>().AsSingle();
        }

        void BindGameSceneState()
        {
            Container.Bind<EditDefaultState>().AsSingle();
            Container.Bind<PlayDefaultState>().AsSingle();
            Container.Bind<CharacterPlacementEditState>().AsSingle();
            Container.Bind<CharacterSelectedEditState>().AsSingle();
        }
    }
}