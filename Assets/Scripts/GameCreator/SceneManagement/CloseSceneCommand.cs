using GameCreator.Framework;
using Zenject;

namespace GameCreator.SceneManagement
{
    public class CloseSceneCommand : ACommand<SceneId>
    {
        [Inject] SceneLoader sceneLoader;

        public override void Execute(SceneId sceneId)
        {
            sceneLoader.Unload(sceneId);
        }
    }
}