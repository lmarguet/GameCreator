using Exoa.Designer;
using GameCreator.Config;
using GameCreator.Features.Characters.Ui;
using GameCreator.Features.GameScene.States;
using GameCreator.SceneManagement;
using Lean.Touch;
using Signals;
using UnityEngine;
using Zenject;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot : ASceneRoot
    {
        public readonly Signal OnGlobalMouseUp = new Signal();

        [Inject] CharactersConfig charactersConfig;

        [Inject] EditDefaultState editDefaultState;
        [Inject] PlayDefaultState playDefaultState;
        [Inject] CharacterPlacementEditState characterPlacementEditState;
        [Inject] CharacterSelectedEditState characterSelectedEditState;

        [SerializeField] Camera sceneCamera;
        [SerializeField] LayerMask terrainLayer;
        [SerializeField] LayerMask charactersLayer;
        [SerializeField] Transform charactersContainer;
        [SerializeField] CharacterWolrdUi characterWorldUi;
        [SerializeField] Inputs cameraInputs;
        [SerializeField] TerrainView terrainView;

        static readonly Quaternion CharacterInitRotation = Quaternion.Euler(0, 180, 0);

        bool isMousePressed;
        GameSceneMode currentMode = GameSceneMode.EditMode;
        IGameSceneState state;

        public TerrainView TerrainView => terrainView;

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
        }

        void SetState(IGameSceneState gameSceneState)
        {
            if (state != null)
            {
                state.Disable();
            }

            Debug.Log($"State update: {state} -> {gameSceneState}");
            state = gameSceneState.Enable(this);
        }

        public void SetDefaultEditState()
        {
            SetState(editDefaultState);
        }
    }
}