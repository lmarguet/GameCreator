using GameCreator.Framework;
using GameCreator.SceneManagement;
using Zenject;

namespace GameCreator.Features.GameScene
{
    public class DeselectCharacterCommand : ACommand
    {
        [Inject] NavigationManager navigationManager;

        public override void Execute()
        {
            var gameSceneRoot = navigationManager.GetScene<GameSceneRoot>();
            gameSceneRoot.DeselectCharacter();
        }
    }
}