using Exoa.Designer;
using Lean.Touch;
using Signals;
using UnityEngine;

namespace GameCreator.Features.Characters
{
    [RequireComponent(typeof(Animator))]
    public class CharacterView : MonoBehaviour
    {
        public readonly Signal<CharacterView> MouseUp = new Signal<CharacterView>();
        public readonly Signal<CharacterView> MouseDown = new Signal<CharacterView>();
        public readonly Signal<CharacterView> MouseDrag = new Signal<CharacterView>();

        Animator animator;
        Vector3 screenPoint;
        Vector3 offset;

        public CharacterType CharacterType { get; private set; }

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
            CharacterType = type;
        }
        
        void OnMouseUp()
        {
            ProcessEvent(MouseUp);
        }

        void OnMouseDown()
        {
            ProcessEvent(MouseDown);
        }
        
        void OnMouseDrag()
        {;
            ProcessEvent(MouseDrag);
        }

        void ProcessEvent(Signal<CharacterView> signal)
        {
            if (!LeanTouch.PointOverGui(Input.mousePosition))
            {
                signal.Dispatch(this);
            }
        }
    }
}