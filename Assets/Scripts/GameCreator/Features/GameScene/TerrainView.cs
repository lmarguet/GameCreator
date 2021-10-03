using System;
using System.Linq;
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

        public int brushWidth;
        public int brushHeight;

        [Range(0.001f, 0.1f)]
        [SerializeField] float strength;

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

        public void Raise(RaycastHit hit)
        {
            RaiseTerrain(hit.point, strength, brushWidth, brushHeight);
        }

        Vector3 WorldToTerrainPosition(Vector3 worldPosition)
        {
            var terrainPosition = worldPosition - targetTerrain.GetPosition();
            var terrainSize = TerrainSize;

            var positionX = terrainPosition.x / terrainSize.x;
            var positionZ = terrainPosition.z / terrainSize.z;

            return new Vector3(positionX * HeightMapResolution, 0, positionZ);
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

        public void RaiseTerrain(Vector3 worldPosition, float strength, int brushWidth, int brushHeight)
        {
            var brushPosition = GetBrushPosition(worldPosition, brushWidth, brushHeight);

            var brushSize = GetSafeBrushSize(brushPosition.x, brushPosition.y, brushWidth, brushHeight);

            var terrainData = TerrainData;

            var heights = terrainData.GetHeights(brushPosition.x, brushPosition.y, brushSize.x, brushSize.y);

            for (var i = 0; i < brushSize.y; i++)
            {
                for (var j = 0; j < brushSize.x; j++)
                {
                    heights[i, j] += strength * Time.deltaTime;
                }
            }

            terrainData.SetHeights(brushPosition.x, brushPosition.y, heights);
        }

        public void LowerTerrain(Vector3 worldPosition, float strength, int brushWidth, int brushHeight)
        {
            var brushPosition = GetBrushPosition(worldPosition, brushWidth, brushHeight);

            var brushSize = GetSafeBrushSize(brushPosition.x, brushPosition.y, brushWidth, brushHeight);

            var terrainData = TerrainData;

            var heights = terrainData.GetHeights(brushPosition.x, brushPosition.y, brushSize.x, brushSize.y);

            for (var i = 0; i < brushSize.y; i++)
            {
                for (var j = 0; j < brushSize.x; j++)
                {
                    heights[i, j] -= strength * Time.deltaTime;
                }
            }

            terrainData.SetHeights(brushPosition.x, brushPosition.y, heights);
        }
    }
}