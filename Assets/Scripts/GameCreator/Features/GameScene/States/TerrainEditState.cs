using UnityEngine;

namespace GameCreator.Features.GameScene.States
{
    public class TerrainEditState : AGameSceneState
    {
        Vector3 editPosition;
        
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
            gameSceneRoot.DoTerrainMouseRaycast(out var hit);
            editPosition = hit.point;
            gameSceneRoot.ModifyTerrain(editPosition);
        }
    }
}