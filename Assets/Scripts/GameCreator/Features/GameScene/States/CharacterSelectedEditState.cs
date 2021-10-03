using GameCreator.Config;
using GameCreator.Features.Characters;
using UnityEngine;
using Zenject;

namespace GameCreator.Features.GameScene.States
{
    public class CharacterSelectedEditState : AGameSceneState
    {
        [Inject] GlobalConfig globalConfig;

        CharacterView selectedCharacter;
        Vector2 startDragPosition;

        public void Select(CharacterView character)
        {
            selectedCharacter = character;
            gameSceneRoot.ShowCharacterUi(selectedCharacter);
            selectedCharacter.IsSelected = true;
            startDragPosition = Input.mousePosition;
        }

        protected override void OnEnable()
        {
            gameSceneRoot.TerrainView.MouseDown.AddListener(HandleTerrainMouseDown);
            gameSceneRoot.OnCharacterMouseDown.AddListener(HandleCharacterMouseDown);
            gameSceneRoot.OnCharacterDrag.AddListener(HandleCharacterDrag);

            gameSceneRoot.SetCameraControlsEnabled(false);
        }

        protected override void OnDisable()
        {
            gameSceneRoot.TerrainView.MouseDown.RemoveListener(HandleTerrainMouseDown);
            gameSceneRoot.OnCharacterMouseDown.RemoveListener(HandleCharacterMouseDown);
            gameSceneRoot.OnCharacterDrag.RemoveListener(HandleCharacterDrag);

            selectedCharacter.IsSelected = false;
            selectedCharacter = null;
            gameSceneRoot.SetCameraControlsEnabled(true);
        }

        void HandleCharacterMouseDown(CharacterView characterView)
        {
            if (characterView == selectedCharacter)
            {
                startDragPosition = Input.mousePosition;
                return;
            }

            gameSceneRoot.SelectCharacter(characterView);
        }

        void HandleTerrainMouseDown()
        {
            gameSceneRoot.SetDefaultEditState();
        }

        void HandleCharacterDrag(CharacterView character)
        {
            var dragPosition = Input.mousePosition;
            var dragDistance = Vector2.Distance(dragPosition, startDragPosition);

            if (dragDistance >= globalConfig.CharacterDragTreshold)
            {
                gameSceneRoot.StartDraggingCharacter(character);
            }
        }
    }
}