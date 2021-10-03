using GameCreator.Features.TerrainEdit;
using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        public TerrainView TerrainView => terrainView;
        public TerrainEditMode TerrainEditMode => terrainEditMode;

        public bool DoTerrainMouseRaycast(out RaycastHit hit)
        {
            var ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit, Mathf.Infinity, terrainLayer.value);
        }

        public void StartEditingTerrain()
        {
            SetState(terrainEditState);
        }

        public void StopEditingTerrain()
        {
            SetState(editDefaultState);
        }

        public void ModifyTerrain(Vector3 editPosition)
        {
            if (terrainEditMode == TerrainEditMode.Raise)
            {
                terrainView.Raise(editPosition);
            }
            else
            {
                terrainView.Lower(editPosition);
            }
        }

        public void SetTerranEditMode(TerrainEditMode mode)
        {
            terrainEditMode = mode;
        }
    }
}