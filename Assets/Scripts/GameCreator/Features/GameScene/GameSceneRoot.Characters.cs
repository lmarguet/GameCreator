using System.Collections.Generic;
using GameCreator.Features.Characters;
using UnityEngine;
using Zenject;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        [Inject] SelectCharacterCommand selectCharacterCommand;
        [Inject] DeselectCharacterCommand deselectCharacterCommand;
        
        readonly List<CharacterView> characterViews = new List<CharacterView>();

        string characterCreationTargetId;
        bool isCharacterPressed;
        bool isCharacterSelected;

        public void SetCharacterCreationTarget(string characterId)
        {
            characterCreationTargetId = characterId;
        }

        public void ClearCharacterCreationTarget()
        {
            characterCreationTargetId = null;
        }

        void AddCharacter(string character, Vector3 hitPoint)
        {
            clearCharacterCreationSelection.Execute();

            var config = charactersConfig.GetCharacterConfig(character);

            var characterView = Instantiate(config.Prefab, hitPoint, CharacterInitRotation).GetComponent<CharacterView>();
            characterView.transform.parent = charactersContainer;
            characterViews.Add(characterView);
        }

        public void StopAllCharactersAnimations()
        {
            foreach (var characterView in characterViews)
            {
                characterView.StopAnimating();
            }
        }

        public void StartAllCharactersAnimations()
        {
            foreach (var characterView in characterViews)
            {
                characterView.StartAnimating();
            }
        }

        void OnCharacterPress(RaycastHit hitInfo)
        {
            if (!isCharacterPressed)
            {
                OnCharacterMouseDown(hitInfo);
            }

            isCharacterPressed = true;
        }

        void OnCharacterMouseDown(RaycastHit hitInfo)
        {
            if (isCharacterSelected)
            {
                DeselectCharacter();
            }
            isCharacterSelected = true;
            selectCharacterCommand.Execute();
        }

        void DeselectCharacter()
        {
            isCharacterSelected = false;
            deselectCharacterCommand.Execute();
        }
    }
}