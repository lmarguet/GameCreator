using GameCreator.Config;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Features.EditMode.ToolBars
{
    public class CharacterButton : MonoBehaviour
    {
        [SerializeField] Image image;

        string characterId;

        public void SetCharacter(CharactersConfig.CharacterConfig characterConfig)
        {
            characterId = characterConfig.Id;
            image.sprite = characterConfig.ThumbNail;
        }
    }
}