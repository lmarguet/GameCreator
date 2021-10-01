using GameCreator.Config;
using GameCreator.SceneManagement;
using UnityEngine;
using Zenject;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot : ASceneRoot
    {
        [Inject] CharactersConfig charactersConfig;
        [Inject] DeselectCharacterCommand deselectCharacterCommand;
        
        [SerializeField] Camera sceneCamera;
        [SerializeField] LayerMask terrainLayer;
        [SerializeField] Transform charactersContainer;

        static readonly Quaternion CharacterInitRotation = Quaternion.Euler(0, 180, 0);
        
        bool isMousePressed;

        void Start()
        {
            Debug.Log("[GameSceneRoot] Start");
            isMousePressed = false;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isMousePressed = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isMousePressed = false;
            }

            if (isMousePressed)
            {
                var ray = sceneCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit))
                {
                    var layerMask = 1 << hit.transform.gameObject.layer;
                    if (layerMask == terrainLayer.value)
                    {
                        OnTerrainPress(hit.point);
                    }
                }
            }
            else
            {
                isTerrainPressed = false;
            }
        }

        public void EnterEditMode()
        {
            StopAllCharactersAnimations();
        }

        public void EnterPlayMode()
        {
            StartAllCharactersAnimations();
        }
    }
}