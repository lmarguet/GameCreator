using System.Collections.Generic;
using GameCreator.Features.Characters;
using Signals;
using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        public readonly Signal<RaycastHit> OnCharacterMouseDown = new Signal<RaycastHit>();
        public readonly Signal<RaycastHit> OnCharacterPress = new Signal<RaycastHit>();

        readonly List<CharacterView> characterViews = new List<CharacterView>();

        bool isCharacterPressed;

        void HandleCharacterPress(RaycastHit hitInfo)
        {
            if (!isCharacterPressed)
            {
                OnCharacterMouseDown.Dispatch(hitInfo);
            }

            OnCharacterPress.Dispatch(hitInfo);
            isCharacterPressed = true;
        }
        
        public void StartPlacingCharacter(string characterId)
        {
            SetState(characterPlacementEditState);
            characterPlacementEditState.SetCharacterId(characterId);
        }

        public void AddCharacter(string character, Vector3 hitPoint)
        {
            var config = charactersConfig.GetCharacterConfig(character);

            var characterView = Instantiate(config.Prefab, hitPoint, CharacterInitRotation).GetComponent<CharacterView>();
            characterView.transform.parent = charactersContainer;
            characterViews.Add(characterView);
        }

        public void ShowCharacterUi(GameObject character)
        {
            characterWolrdUi.Show(character, sceneCamera.transform);
        }

        public void HideCharacterUi()
        {
            characterWolrdUi.Hide(charactersContainer);
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

        public void SelectCharacter(GameObject character)
        {
            SetState(characterSelectedEditState);
            characterSelectedEditState.Select(character);
        }
    }
}