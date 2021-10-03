using GameCreator.Features.TerrainEdit;
using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        float[,] previousTerrainHeights;
        public TerrainView TerrainView => terrainView;

        public bool DoTerrainMouseRaycast(out RaycastHit hit)
        {
            var ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit, Mathf.Infinity, terrainLayer.value);
        }

        public void StartEditingTerrain()
        {
            SetState(terrainEditState);
            previousTerrainHeights = terrainView.GetHeights();
        }

        public void StopEditingTerrain()
        {
            SetState(editDefaultState);
        }

        public void ModifyTerrain(Vector3 editPosition)
        {
            if (terrainEditMode == TerrainEditMode.Raise)
            {
                terrainView.Raise(editPosition, terrainBrushDiameter, terrainEditConfig.StrengthRange.x);
            }
            else
            {
                terrainView.Lower(editPosition, terrainBrushDiameter, terrainEditConfig.StrengthRange.x);
            }
        }

        public void SetTerranEditMode(TerrainEditMode mode)
        {
            terrainEditMode = mode;
        }

        public void SetTerrainBrushDiameter(float rangePercent)
        {
            var range = terrainEditConfig.DiameterRange.y - terrainEditConfig.DiameterRange.x;
            terrainBrushDiameter = Mathf.RoundToInt(terrainEditConfig.DiameterRange.x + range * rangePercent);
        }

        public void ClearLatestTerrainModifications()
        {
            terrainView.ResetHeightsToState(previousTerrainHeights);
        }
    }
}