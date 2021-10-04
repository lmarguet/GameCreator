using GameCreator.Config;
using UnityEngine;
using Zenject;

namespace GameCreator.Injection
{
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ProjectConfigInstaller")]
    public class ProjectConfigInstaller : ScriptableObjectInstaller<ProjectConfigInstaller>
    {
        [SerializeField] GlobalConfig globalConfig;
        [SerializeField] ScenesConfig scenesConfig;
        [SerializeField] CharactersConfig charactersConfig;
        [SerializeField] TerrainEditConfig terrainEditConfig;
        [SerializeField] WeatherApiConfig weatherApiConfig;

        public override void InstallBindings()
        {
            Debug.Log("[ProjectConfigInstaller] Installing bindings");

            Container.BindInstance(globalConfig);
            Container.BindInstance(scenesConfig);
            Container.BindInstance(charactersConfig);
            Container.BindInstance(terrainEditConfig);
            Container.BindInstance(weatherApiConfig);
        }
    }
}