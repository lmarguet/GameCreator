namespace GameCreator.Features.GameScene.States
{
    public abstract class AGameSceneState : IGameSceneState
    {
        protected GameSceneRoot gameSceneRoot;

        bool isEnabled;

        public bool IsEnabled => isEnabled;

        public IGameSceneState Enable(GameSceneRoot root)
        {
            isEnabled = true;
            gameSceneRoot = root;
            OnEnable();
            return this;
        }

        protected virtual void OnEnable()
        {
        }

        public void Disable()
        {
            isEnabled = false;
        }

        protected virtual void OnDisable()
        {
        }
    }
}