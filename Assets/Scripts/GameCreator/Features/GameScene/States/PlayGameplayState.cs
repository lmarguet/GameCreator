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

        protected override void OnEnable()
        {
            gameSceneRoot.StartAllCharactersAnimations();
            playerView.EnableControls();
            gameSceneRoot.SetCameraControlsEnabled(false);
            gameSceneRoot.SetupPlayerCamera(playerView.gameObject);
            gameSceneRoot.StartRealTimeUpdate();
        }

        protected override void OnDisable()
        {
            playerView.DisableControls();
            gameSceneRoot.SetCameraControlsEnabled(true);
            gameSceneRoot.ResetCamera();
            gameSceneRoot.StopRealTimeUpdate();
        }
    }
}