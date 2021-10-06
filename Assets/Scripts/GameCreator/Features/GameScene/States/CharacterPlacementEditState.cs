using GameCreator.Features.Characters;
using Zenject;

namespace GameCreator.Features.GameScene.States
{
    public class CharacterPlacementEditState : AGameSceneState
    {
        [Inject] StopCharacterPlacementCommand stopCharacterPlacementCommand;
        
        string characterId;

        public void SetCharacterId(string id)
        {
            characterId = id;
        }
        
        protected override void OnEnable()
        {
            gameSceneRoot.TerrainView.MouseDown.AddListener(HandleTerrainMouseDown);
            gameSceneRoot.OnCharacterPlacementSelected.AddListener(HandleCharacterPlacementSelect);
        }

        void HandleTerrainMouseDown()
        {
            gameSceneRoot.DoMouseRaycast(out var hit);
            
            gameSceneRoot.AddCharacter(characterId, hit.point);
            stopCharacterPlacementCommand.Execute();
        }

        protected override void OnDisable()
        {
            gameSceneRoot.TerrainView.MouseDown.RemoveListener(HandleTerrainMouseDown);
            gameSceneRoot.OnCharacterPlacementSelected.RemoveListener(HandleCharacterPlacementSelect);
            characterId = null;
        }

        void HandleCharacterPlacementSelect(string character)
        {
            SetCharacterId(character);
        }
    }
}