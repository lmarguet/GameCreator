using GameCreator.Features.Characters;

namespace GameCreator.Features.GameScene.States
{
    public class PlayGameplayState : AGameSceneState
    {
        CharacterView playerView;

        public void SetPlayerView(CharacterView characterView)
        {
            playerView = characterView;
        }
    }
}