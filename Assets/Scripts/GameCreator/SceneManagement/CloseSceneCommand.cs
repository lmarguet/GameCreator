using GameCreator.Framework;
using UnityEngine;
using Zenject;

namespace GameCreator.SceneManagement
{
    public class CloseSceneCommand : ACommand<SceneId>
    {
        [Inject] SceneLoader sceneLoader;

        public override void Execute(SceneId sceneId)
        {
            Debug.Log($"[CloseSceneCommand] {sceneId}");
            sceneLoader.Unload(sceneId);
        }
    }
}