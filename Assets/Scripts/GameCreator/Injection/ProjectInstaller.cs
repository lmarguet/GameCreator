using UnityEngine;
using Zenject;

namespace GameCreator.Injection
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("[ProjectInstaller] Installing bindings");
        }
    }
}