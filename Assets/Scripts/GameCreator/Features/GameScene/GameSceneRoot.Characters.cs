using System.Collections.Generic;
using System.Linq;
using GameCreator.Features.Characters;
using Signals;
using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        public readonly Signal<CharacterView> OnCharacterMouseDown = new Signal<CharacterView>();
        public readonly Signal<CharacterView> OnCharacterMouseUp = new Signal<CharacterView>();
        public readonly Signal<CharacterView> OnCharacterDrag = new Signal<CharacterView>();
        public readonly Signal<string> OnCharacterPlacementSelected = new Signal<string>();

        readonly List<CharacterView> characterViews = new List<CharacterView>();

        public void SetCharacterToPlace(string characterId)
        {
            OnCharacterPlacementSelected.Dispatch(characterId);
        }

        public void StartCharacterPlacement(string characterId)
        {
            SetState(characterPlacementEditState);
            characterPlacementEditState.SetCharacterId(characterId);
        }
        
        public void AddCharacter(string character, Vector3 hitPoint)
        {
            var config = charactersConfig.GetCharacterConfig(character);

            var characterView = Instantiate(config.Prefab, hitPoint, Quaternion.identity).GetComponent<CharacterView>();
            characterView.transform.parent = charactersContainer;
            characterView.DisableControls();

            var characterType = characterViews.Count == 0 ? CharacterType.Player : CharacterType.NPC;
            characterView.SetType(characterType);
            characterView.MouseDown.AddListener(HandleCharacterMouseDown);
            characterView.MouseUp.AddListener(HandleCharacterMouseUp);
            characterView.MouseDrag.AddListener(HandleCharacterDrag);

            characterViews.Add(characterView);
        }

        public void DeleteCharacter(CharacterView character)
        {
            HideCharacterUi();
            characterViews.Remove(character);

            character.MouseDown.RemoveListener(HandleCharacterMouseDown);
            character.MouseUp.RemoveListener(HandleCharacterMouseUp);
            character.MouseDrag.RemoveListener(HandleCharacterDrag);

            Destroy(character.gameObject);

            if (characterViews.Count == 1)
            {
                characterViews[0].SetType(CharacterType.Player);
            }

            SetState(editDefaultState);
        }

        void HandleCharacterMouseDown(CharacterView character)
        {
            OnCharacterMouseDown.Dispatch(character);
        }

        void HandleCharacterMouseUp(CharacterView character)
        {
            OnCharacterMouseUp.Dispatch(character);
        }

        void HandleCharacterDrag(CharacterView character)
        {
            OnCharacterDrag.Dispatch(character);
        }

        public void ShowCharacterUi(CharacterView character)
        {
            characterWorldUi.Show(character, sceneCamera.transform);
        }

        public void HideCharacterUi()
        {
            characterWorldUi.Hide(charactersContainer);
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

        public void SelectCharacter(CharacterView character)
        {
            SetState(characterSelectedEditState);
            characterSelectedEditState.Select(character);
        }

        public void SetCharacterType(CharacterView characterView, CharacterType characterType)
        {
            if (characterType == CharacterType.Player)
            {
                foreach (var view in characterViews)
                {
                    view.SetType(CharacterType.NPC);
                }
            }

            characterView.SetType(characterType);
        }

        public void StartDraggingCharacter(CharacterView character)
        {
            SetState(characterDragEditState);
            characterDragEditState.SetCharacter(character);
        }

        public bool HasPlayableCharacter()
        {
            return HasPlayableCharacter(out var characterView);
        }

        public bool HasPlayableCharacter(out CharacterView characterView)
        {
            characterView = characterViews.FirstOrDefault(x => x.CharacterType == CharacterType.Player);
            return characterView != null;
        }
    }
}