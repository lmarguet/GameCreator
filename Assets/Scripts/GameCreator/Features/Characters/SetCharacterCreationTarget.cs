using GameCreator.Features.GameScene;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using Zenject;

namespace GameCreator.Features.Characters
{
    public class SetCharacterCreationTarget : ACommand<string>
    {
        [Inject] NavigationManager navigationManager;
        
        public override void Execute(string characterId)
        {
            var gameSceneRoot = navigationManager.GetScene<GameSceneRoot>();
            gameSceneRoot.SetCharacterCreationTarget(characterId);
        }
    }
}