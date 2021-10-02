using GameCreator.Features.GameScene;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using Zenject;

namespace GameCreator.Features.Characters
{
    public class DeleteCharacterCommand : ACommand<CharacterView>
    {
        [Inject] NavigationManager navigationManager;
        
        public override void Execute(CharacterView character)
        {
            var gameSceneRoot = navigationManager.GetScene<GameSceneRoot>();
            gameSceneRoot.DeleteCharacter(character);
        }
    }
}