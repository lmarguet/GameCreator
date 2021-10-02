using UnityEngine;

namespace GameCreator.Features.Characters
{
    [RequireComponent(typeof(Animator))]
    public class CharacterView : MonoBehaviour
    {
        Animator animator;

        public CharacterType characterType { get; private set; }

        void Awake()
        {
            animator = GetComponent<Animator>();
            StopAnimating();
        }

        public void StopAnimating()
        {
            animator.enabled = false;
        }

        public void StartAnimating()
        {
            animator.enabled = true;
        }

        public void SetType(CharacterType type)
        {
            characterType = type;
        }
    }
}