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
        {;
            gameSceneRoot.SetCameraControlsEnabled(false);
            var camera = gameSceneRoot.SetupPlayerCamera(playerView.gameObject);
            playerView.EnableControls(camera.transform);
        }

        protected override void OnDisable()
        {
            playerView.DisableControls();
            gameSceneRoot.SetCameraControlsEnabled(true);
            gameSceneRoot.ResetCamera();
        }
    }
}