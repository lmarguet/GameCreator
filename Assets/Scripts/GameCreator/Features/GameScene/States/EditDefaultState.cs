namespace GameCreator.Features.GameScene.States
{
    public class EditDefaultState : AGameSceneState
    {
        protected override void OnEnable()
        {
            gameSceneRoot.StopAllCharactersAnimations();
        }
    }
}