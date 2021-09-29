using GameCreator.Config;
using UnityEngine;
using Zenject;

namespace GameCreator.Injection
{
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ProjectConfigInstaller")]
    public class ProjectConfigInstaller : ScriptableObjectInstaller<ProjectConfigInstaller>
    {
        [SerializeField] private GlobalConfig globalConfig;
        [SerializeField] private ScenesConfig scenesConfig;

        public override void InstallBindings()
        {
            Debug.Log("[ProjectConfigInstaller] Installing bindings");
            
            Container.BindInstance(globalConfig);
            Container.BindInstance(scenesConfig);
        }
    }
}