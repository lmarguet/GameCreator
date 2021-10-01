using GameCreator.Framework;
using GameCreator.SceneManagement;
using Zenject;

namespace GameCreator.Features.GameScene
{
    public class SelectedCharacterCommand : ACommand<string>
    {
        [Inject] NavigationManager navigationManager;
        
        public override void Execute(string characterId)
        {
            var gameSceneRoot = navigationManager.GetScene<GameSceneRoot>();
            gameSceneRoot.SetSelectedCharacter(characterId);
        }
    }
}