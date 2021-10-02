using System.Collections.Generic;
using GameCreator.Features.Characters;
using Signals;
using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        public readonly Signal<CharacterView> OnCharacterMouseDown = new Signal<CharacterView>();
        public readonly Signal<CharacterView> OnCharacterPress = new Signal<CharacterView>();
        public readonly Signal<CharacterView> OnCharacterDrag = new Signal<CharacterView>();

        readonly List<CharacterView> characterViews = new List<CharacterView>();

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

            var characterType = characterViews.Count == 0 ? CharacterType.Player : CharacterType.NPC;
            characterView.SetType(characterType);
            characterView.MouseDown.AddListener(() => OnCharacterMouseDown.Dispatch(characterView));
            characterView.MouseUp.AddListener(() => OnCharacterPress.Dispatch(characterView));
            characterView.MouseDrag.AddListener(() => OnCharacterDrag.Dispatch(characterView));

            characterViews.Add(characterView);
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

        public void DeleteCharacter(CharacterView character)
        {
            HideCharacterUi();
            characterViews.Remove(character);
            
            character.MouseDown.RemoveAllListeners();
            character.MouseUp.RemoveAllListeners();
            character.MouseDrag.RemoveAllListeners();
            
            Destroy(character.gameObject);

            if (characterViews.Count == 1)
            {
                characterViews[0].SetType(CharacterType.Player);
            }

            SetState(editDefaultState);
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
    }
}