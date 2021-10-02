using GameCreator.Framework;
using UnityEngine;

namespace GameCreator.Features.Characters
{
    public class DeselectCharacterCommand : ACommand
    {
        public override void Execute()
        {
            Debug.Log("DeselectCharacterCommand");
        }
    }
}