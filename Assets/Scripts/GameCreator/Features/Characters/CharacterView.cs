using UnityEngine;

namespace GameCreator.Features.Characters
{
    [RequireComponent(typeof(Animator))]
    public class CharacterView : MonoBehaviour
    {
        Animator animator;

        void Awake()
        {
            animator = GetComponent<Animator>();
            animator.enabled = false;
        }
        
        
    }
}