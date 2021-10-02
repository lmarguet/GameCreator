using System;
using System.Linq;
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

            public string Id => id;
            public GameObject Prefab => prefab;
            public Sprite ThumbNail => thumbNail;
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

        public CharacterConfig GetCharacterConfig(string id)
        {
            return characters.First(x => x.Id == id);
        }
    }
}