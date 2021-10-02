using GameCreator.Config;
using GameCreator.Features.Characters;
using GameCreator.Features.GameScene.States;
using GameCreator.SceneManagement;
using Lean.Touch;
using UnityEngine;
using Zenject;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot : ASceneRoot
    {
        [Inject] CharactersConfig charactersConfig;
        [Inject] ClearCharacterCreationSelection clearCharacterCreationSelection;

        [Inject] EditDefaultState editDefaultState;
        [Inject] PlayDefaultState playDefaultState;
        [Inject] EditCharacterPlacementState editCharacterPlacementState;
        [Inject] EditCharacterSelectedState editCharacterSelectedState;
        
        [SerializeField] Camera sceneCamera;
        [SerializeField] LayerMask terrainLayer;
        [SerializeField] LayerMask charactersLayer;
        [SerializeField] Transform charactersContainer;

        static readonly Quaternion CharacterInitRotation = Quaternion.Euler(0, 180, 0);
        
        bool isMousePressed;
        GameSceneMode currentMode = GameSceneMode.EditMode;
        IGameSceneState state;

        void Start()
        {
            Debug.Log("[GameSceneRoot] Start");
            isMousePressed = false;
        }

        void Update()
        {
            if (currentMode == GameSceneMode.EditMode)
            {
                CheckMouseInteraction();   
            }
        }

        void CheckMouseInteraction()
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
                if (LeanTouch.PointOverGui(Input.mousePosition))
                {
                    return;
                }

                var ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    OnMouseDownRaycast(hit);
                }
            }
            else
            {
                isTerrainPressed = false;
                isCharacterPressed = false;
            }
        }

        void OnMouseDownRaycast(RaycastHit hit)
        {
            var layerMask = 1 << hit.transform.gameObject.layer;
            if (layerMask == terrainLayer.value)
            {
                OnTerrainPress(hit.point);
            }

            if (layerMask == charactersLayer)
            {
                OnCharacterPress(hit);
            }
        }

        public void EnterEditMode()
        {
            currentMode = GameSceneMode.EditMode;
            SetState(editDefaultState);
        }

        public void EnterPlayMode()
        {
            currentMode = GameSceneMode.PlayMode;
            SetState(playDefaultState);
        }

        void SetState(IGameSceneState gameSceneState)
        {
            if (state != null)
            {
                state.Disable();
            }
            state = gameSceneState.Enable(this);
        }
    }
}