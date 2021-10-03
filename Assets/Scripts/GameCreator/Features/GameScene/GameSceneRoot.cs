using Exoa.Cameras;
using Exoa.Designer;
using GameCreator.Config;
using GameCreator.Features.Characters.Ui;
using GameCreator.Features.GameScene.States;
using GameCreator.Features.TerrainEdit;
using GameCreator.SceneManagement;
using Signals;
using UnityEngine;
using UnityStandardAssets.Cameras;
using Zenject;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot : ASceneRoot
    {
        public readonly Signal OnGlobalMouseUp = new Signal();

        [Inject] CharactersConfig charactersConfig;
        [Inject] TerrainEditConfig terrainEditConfig;

        [Inject] EditDefaultState editDefaultState;
        [Inject] PlayDefaultState playDefaultState;
        [Inject] CharacterPlacementEditState characterPlacementEditState;
        [Inject] CharacterSelectedEditState characterSelectedEditState;
        [Inject] CharacterDragEditState characterDragEditState;
        [Inject] PlayGameplayState playGameplayState;
        [Inject] TerrainEditState terrainEditState;

        [SerializeField] Camera sceneCamera;
        [SerializeField] LayerMask terrainLayer;
        [SerializeField] Transform charactersContainer;
        [SerializeField] CharacterWolrdUi characterWorldUi;
        [SerializeField] Inputs cameraInputs;
        [SerializeField] CameraBase cameraBase;
        [SerializeField] TerrainView terrainView;
        [SerializeField] AutoCam playerCamera;

        bool isMousePressed;
        GameSceneMode currentMode = GameSceneMode.EditMode;
        IGameSceneState state;
        TerrainEditMode terrainEditMode;
        int terrainBrushDiameter;

        void Awake()
        {
            characterWorldUi.gameObject.SetActive(false);
        }

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
                if (isMousePressed)
                {
                    OnGlobalMouseUp.Dispatch();
                }

                isMousePressed = false;
            }
        }

        public bool DoMouseRaycast(out RaycastHit hit)
        {
            var ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit);
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
            
            if (HasPlayableCharacter(out var characterView))
            {
                playGameplayState.SetPlayerView(characterView);
                SetState(playGameplayState);
            }
        }

        void SetState(IGameSceneState gameSceneState)
        {
            state?.Disable();
            Debug.Log($"State update: {state} -> {gameSceneState}");
            state = gameSceneState.Enable(this);
        }

        public void SetDefaultEditState()
        {
            SetState(editDefaultState);
        }
    }
}