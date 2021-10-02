namespace GameCreator.Features.GameScene.States
{
    public interface IGameSceneState
    {
        bool IsEnabled { get; }
        IGameSceneState Enable(GameSceneRoot root);
        void Disable();
    }
}