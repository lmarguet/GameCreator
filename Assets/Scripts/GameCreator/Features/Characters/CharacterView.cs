using Signals;
using UnityEngine;

namespace GameCreator.Features.Characters
{
    [RequireComponent(typeof(Animator))]
    public class CharacterView : MonoBehaviour
    {
        readonly public Signal MouseUp = new Signal();
        readonly public Signal MouseDown = new Signal();
        readonly public Signal MouseDrag = new Signal();

        Animator animator;
        Vector3 screenPoint;
        Vector3 offset;

        public CharacterType characterType { get; private set; }

        public bool IsSelected { get; set; }

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
        
        void OnMouseUp()
        {
            MouseUp.Dispatch();
        }
        
        void OnMouseDown()
        {
            MouseDown.Dispatch();
        }
        
        void OnMouseDrag()
        {
            MouseDrag.Dispatch();
        }
    }
}