using System.Collections.Generic;
using GameCreator.Features.Characters;

namespace GameCreator.Features.GameScene
{
    public partial class GameSceneRoot
    {
        public void SaveObjectStates()
        {
            objectsSaveData = new Dictionary<int, SavableView.SaveData>();

            foreach (var characterView in characterViews)
            {
                var saveData = characterView.GetSaveState();
                objectsSaveData.Add(characterView.GetId(), saveData);
            }
        }

        public void ResetObjectStates()
        {
            foreach (var characterView in characterViews)
            {
                var id = characterView.GetId();
                var saveData = objectsSaveData[id];
                characterView.ResetToSaveState(saveData);
            }
        }
    }
}