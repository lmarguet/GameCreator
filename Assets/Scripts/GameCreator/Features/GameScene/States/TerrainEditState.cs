namespace GameCreator.Features.GameScene.States
{
    public class TerrainEditState : AGameSceneState
    {
        protected override void OnEnable()
        {
            gameSceneRoot.TerrainView.MouseDrag.AddListener(HandleTerrainDrag);
            gameSceneRoot.SetCameraControlsEnabled(false);
        }

        protected override void OnDisable()
        {
            gameSceneRoot.TerrainView.MouseDrag.RemoveListener(HandleTerrainDrag);
            gameSceneRoot.SetCameraControlsEnabled(true);
        }

        void HandleTerrainDrag()
        {
            gameSceneRoot.ModifyTerrain();
        }
    }
}