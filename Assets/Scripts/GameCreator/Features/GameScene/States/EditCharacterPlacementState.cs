using GameCreator.Features.Characters;
using UnityEngine;
using Zenject;

namespace GameCreator.Features.GameScene.States
{
    public class EditCharacterPlacementState : AGameSceneState
    {
        [Inject] StopCharacterPlacementCommand stopCharacterPlacementCommand;
        
        string characterId;

        public void SetCharacterId(string id)
        {
            characterId = id;
        }
        
        protected override void OnEnable()
        {
            gameSceneRoot.OnTerrainMouseDown.AddListener(HandleTerrainMouseDown);
        }

        void HandleTerrainMouseDown(Vector3 position)
        {
            gameSceneRoot.AddCharacter(characterId, position);
            stopCharacterPlacementCommand.Execute();
        }

        protected override void OnDisable()
        {
            gameSceneRoot.OnTerrainMouseDown.RemoveListener(HandleTerrainMouseDown);
            characterId = null;
        }
    }
}