namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        public void SetCameraControllsEnabled(bool enabled)
        {
            cameraInputs.enabled = enabled;
        }
    }
}