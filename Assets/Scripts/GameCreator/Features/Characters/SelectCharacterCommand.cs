using GameCreator.Framework;
using UnityEngine;

namespace GameCreator.Features.Characters
{
    public class SelectCharacterCommand : ACommand
    {
        public override void Execute()
        {
            Debug.Log("SelectCharacterCommand");
        }
    }
}