using UnityEngine;

namespace GameCreator.Features.Characters
{
    
    
    public class SavableView : MonoBehaviour
    {
        
        public struct  SaveData
        {
            public int ID;
            public Vector3 Position;
            public Quaternion Rotation;
        }


        public SaveData GetSaveState()
        {
            return new SaveData
            {
                ID = GetId(),
                Position = transform.position,
                Rotation = transform.rotation
            };
        }

       public int GetId()
        {
            return gameObject.GetInstanceID();
        }

        public void ResetToSaveState(SaveData saveData)
        {
            transform.position = saveData.Position;
            transform.rotation = saveData.Rotation;
        }
    }
}