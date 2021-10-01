using GameCreator.SceneManagement;
using UnityEngine;

namespace GameCreator.Features.GameScene
{
    public class GameSceneRoot : ASceneRoot
    {
        string selectedCharacter;

        void Start()
        {
            Debug.Log("[GameSceneRoot] Start");
        }

        public void SetSelectedCharacter(string characterId)
        {
            selectedCharacter = characterId;
            Debug.Log(selectedCharacter);
        }

        public void DeselectCharacter()
        {
            selectedCharacter = null;
            Debug.Log("deselect");
        }
    }
}