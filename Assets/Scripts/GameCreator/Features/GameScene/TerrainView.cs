using Lean.Touch;
using Signals;
using UnityEngine;

namespace GameCreator.Features.GameScene
{
    [RequireComponent(typeof(Terrain))]
    public class TerrainView : MonoBehaviour
    {
        public readonly Signal MouseUp = new Signal();
        public readonly Signal MouseDown = new Signal();
        public readonly Signal MouseDrag = new Signal();

        Terrain targetTerrain;
        float sampledHeight;
        TerrainData initTerrainData;

        public TerrainData TerrainData => targetTerrain.terrainData;

        int HeightMapResolution => TerrainData.heightmapResolution;
        Vector3 TerrainSize => TerrainData.size;

        void Awake()
        {
            targetTerrain = GetComponent<Terrain>();
        }

        void OnMouseUp()
        {
            ProcessEvent(MouseUp);
        }

        void OnMouseDown()
        {
            ProcessEvent(MouseDown);
        }

        void OnMouseDrag()
        {
            ProcessEvent(MouseDrag);
        }

        void ProcessEvent(Signal signal)
        {
            if (!LeanTouch.PointOverGui(Input.mousePosition))
            {
                signal.Dispatch();
            }
        }

        void OnApplicationQuit()
        {
            ResetTerrain();
        }

        public void ResetTerrain()
        {
            var terrainDataHeightmapResolution = TerrainData.heightmapResolution;
            var heightMap = new float[TerrainData.heightmapResolution, TerrainData.heightmapResolution];

            for (var i = 0; i < terrainDataHeightmapResolution; i++)
            {
                for (var j = 0; j < terrainDataHeightmapResolution; j++)
                {
                    heightMap[i, j] = 0;
                }
            }

            TerrainData.SetHeights(0, 0, heightMap);
        }

        public void ResetHeightsToState(float[,] resetHeights)
        {
            TerrainData.SetHeights(0, 0, resetHeights);
        }

        public float[,] GetHeights()
        {
            return TerrainData.GetHeights(0, 0, TerrainData.heightmapResolution, TerrainData.heightmapResolution);
        }

        public void Raise(Vector3 position, int diameter, float strength)
        {
            RaiseTerrain(position, strength, diameter, diameter);
        }

        public void Lower(Vector3 position, int diameter, float strength)
        {
            LowerTerrain(position, strength, diameter, diameter);
        }

        public Vector3 WorldToTerrainPosition(Vector3 worldPosition)
        {
            var terrainPositionOffset = worldPosition - targetTerrain.GetPosition();
            var heightmapResolution = HeightMapResolution;

            var terrainPositionX = terrainPositionOffset.x / TerrainSize.x * heightmapResolution;
            var terrainPositionZ = terrainPositionOffset.z / TerrainSize.z * heightmapResolution;
            return new Vector3(terrainPositionX, 0, terrainPositionZ);
        }

        Vector2Int GetBrushPosition(Vector3 worldPosition, int brushWidth, int brushHeight)
        {
            var terrainPosition = WorldToTerrainPosition(worldPosition);

            var width = brushWidth / 2.0f;
            var brushPositionX = (int)Mathf.Clamp(terrainPosition.x - width, 0.0f, HeightMapResolution);

            var height = brushHeight / 2.0f;
            var brushPositionZ = (int)Mathf.Clamp(terrainPosition.z - height, 0.0f, HeightMapResolution);

            return new Vector2Int(brushPositionX, brushPositionZ);
        }

        Vector2Int GetSafeBrushSize(int brushX, int brushY, int brushWidth, int brushHeight)
        {
            var heightmapResolution = HeightMapResolution;
            while (heightmapResolution - (brushX + brushWidth) < 0)
            {
                brushWidth--;
            }

            while (heightmapResolution - (brushY + brushHeight) < 0)
            {
                brushHeight--;
            }

            return new Vector2Int(brushWidth, brushHeight);
        }

        void RaiseTerrain(Vector3 worldPosition, float strength, int brushWidth, int brushHeight)
        {
            var brushPosition = GetBrushPosition(worldPosition, brushWidth, brushHeight);
            var brushSize = GetSafeBrushSize(brushPosition.x, brushPosition.y, brushWidth, brushHeight);

            var heights = TerrainData.GetHeights(brushPosition.x, brushPosition.y, brushSize.x, brushSize.y);
            for (var i = 0; i < brushSize.y; i++)
            {
                for (var j = 0; j < brushSize.x; j++)
                {
                    heights[i, j] += strength * Time.deltaTime;
                }
            }

            TerrainData.SetHeights(brushPosition.x, brushPosition.y, heights);
        }

        void LowerTerrain(Vector3 worldPosition, float strength, int brushWidth, int brushHeight)
        {
            var brushPosition = GetBrushPosition(worldPosition, brushWidth, brushHeight);
            var brushSize = GetSafeBrushSize(brushPosition.x, brushPosition.y, brushWidth, brushHeight);

            var heights = TerrainData.GetHeights(brushPosition.x, brushPosition.y, brushSize.x, brushSize.y);

            for (var i = 0; i < brushSize.y; i++)
            {
                for (var j = 0; j < brushSize.x; j++)
                {
                    heights[i, j] -= strength * Time.deltaTime;
                }
            }

            TerrainData.SetHeights(brushPosition.x, brushPosition.y, heights);
        }
    }
}