using GameCreator.Features.GameScene;
using GameCreator.Framework;
using GameCreator.SceneManagement;
using Zenject;

namespace GameCreator.Features.Characters
{
    public class SetCharacterTypeCommand : ACommand<SetCharacterTypeCommand.Data>
    {
        public struct Data
        {
            public CharacterView CharacterView;
            public CharacterType CharacterType;
        }

        [Inject] NavigationManager navigationManager;

        public override void Execute(Data data)
        {
            var gameSceneRoot = navigationManager.GetScene<GameSceneRoot>();
            gameSceneRoot.SetCharacterType(data.CharacterView, data.CharacterType);
        }
    }
}