using System.Collections.Generic;
using GameCreator.Features.Characters;
using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        readonly List<CharacterView> characterViews = new List<CharacterView>();

        string selectedCharacter;

        public void SetSelectedCharacter(string characterId)
        {
            selectedCharacter = characterId;
        }

        public void DeselectCharacter()
        {
            selectedCharacter = null;
        }

        void AddCharacter(string character, Vector3 hitPoint)
        {
            deselectCharacterCommand.Execute();

            var config = charactersConfig.GetCharacterConfig(character);

            var characterView = Instantiate(config.Prefab, hitPoint, CharacterInitRotation).GetComponent<CharacterView>();
            characterView.transform.parent = charactersContainer;
            characterViews.Add(characterView);
        }
        
        void StopAllCharactersAnimations()
        {
            foreach (var characterView in characterViews)
            {
                characterView.StopAnimating();
            }
        }
        
        void StartAllCharactersAnimations()
        {
            foreach (var characterView in characterViews)
            {
                characterView.StartAnimating();
            }
        }
    }
}