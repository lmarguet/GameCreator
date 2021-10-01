using System;
using UnityEngine;

namespace GameCreator.Config
{
    [CreateAssetMenu(fileName = "CharactersConfig", menuName = "Config/CharactersConfig")]
    public class CharactersConfig : ScriptableObject
    {
        [Serializable]
        public class CharacterConfig
        {
            [SerializeField] string id;
            [SerializeField] GameObject prefab;
            [SerializeField] Sprite thumbNail;
        }

        [SerializeField] CharacterConfig[] characters;

        public int NumCharacters => characters.Length;

        public CharacterConfig GetCharacterConfig(int index)
        {
            if (index < 0 || index >= NumCharacters)
            {
                throw new ArgumentException(
                    $"Index {index} for character config is out of bounds, current max valye is: {NumCharacters - 1}");
            }

            return characters[index];
        }
    }
}