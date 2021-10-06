using GameCreator.Features.Characters;
using GameCreator.Features.Characters.EditPopup;
using GameCreator.Features.EditModeUi;
using GameCreator.Features.GameScene;
using GameCreator.Features.GameScene.States;
using GameCreator.Features.PlayMode;
using GameCreator.Features.TerrainEdit;
using GameCreator.Features.TimeSettings;
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
            BindServices();
        }

        void BindCommands()
        {
            Container.Bind<LoadGameSceneCommand>().AsSingle();
            Container.Bind<LoadEditModeCommand>().AsSingle();
            Container.Bind<LoadPlayModeCommand>().AsSingle();

            Container.Bind<StartCharacterPlacementCommand>().AsSingle();
            Container.Bind<StopCharacterPlacementCommand>().AsSingle();

            Container.Bind<OpenEditCharacterPopupCommand>().AsSingle();
            Container.Bind<DeleteCharacterCommand>().AsSingle();
            Container.Bind<SetCharacterTypeCommand>().AsSingle();
            Container.Bind<EnterTerrainEditStateCommand>().AsSingle();
            Container.Bind<ExitTerrainEditStateCommand>().AsSingle();
            Container.Bind<SetTerrainEditModeCommand>().AsSingle();
            Container.Bind<SetTerrainBrushDiameterCommand>().AsSingle();
            Container.Bind<ClearLatestTerrainModifications>().AsSingle();
            Container.Bind<OpenTimeEditPopupCommand>().AsSingle();
            Container.Bind<SetSceneTimeDataCommand>().AsSingle();
            Container.Bind<GetCityDataCommand>().AsSingle();
            Container.Bind<UpdateTimeAndWeatherCommand>().AsSingle();
        }

        void BindGameSceneState()
        {
            Container.Bind<EditDefaultState>().AsSingle();
            Container.Bind<PlayDefaultState>().AsSingle();
            Container.Bind<CharacterPlacementEditState>().AsSingle();
            Container.Bind<CharacterSelectedEditState>().AsSingle();
            Container.Bind<CharacterDragEditState>().AsSingle();
            Container.Bind<PlayGameplayState>().AsSingle();
            Container.Bind<TerrainEditState>().AsSingle();
        }

        void BindServices()
        {
            Container.Bind<WeatherApiService>().AsSingle();
        }
    }
}