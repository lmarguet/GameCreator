namespace GameCreator.Features.GameScene.States
{
    public class PlayDefaultState : AGameSceneState
    {
        protected override void OnEnable()
        {
            gameSceneRoot.StartAllCharactersAnimations();
            gameSceneRoot.StartRealTimeUpdate();
        }

        protected override void OnDisable()
        {
            gameSceneRoot.StopRealTimeUpdate();
        }
    }
}