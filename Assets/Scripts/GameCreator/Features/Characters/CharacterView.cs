using System;
using Lean.Touch;
using Signals;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace GameCreator.Features.Characters
{
    public class CharacterView : MonoBehaviour
    {
        public readonly Signal<CharacterView> MouseUp = new Signal<CharacterView>();
        public readonly Signal<CharacterView> MouseDown = new Signal<CharacterView>();
        public readonly Signal<CharacterView> MouseDrag = new Signal<CharacterView>();
        
        ThirdPersonUserControl controls;
        Animator animator;
        Vector3 screenPoint;
        Vector3 offset;
        ThirdPersonCharacter character; 
        Vector3 move;

        bool areControlsEnabled;
        public CharacterType CharacterType { get; private set; }

        public bool IsSelected { get; set; }

        void Awake()
        {
            animator = GetComponent<Animator>();
            controls = GetComponent<ThirdPersonUserControl>();
            character = GetComponent<ThirdPersonCharacter>();
        }

        public void StopAnimating()
        {
            animator.enabled = false;
        }

        public void StartAnimating()
        {
            animator.enabled = true;
        }

        public void DisableControls()
        {
            controls.enabled = false;
            areControlsEnabled = false;
        }

        public void EnableControls(Transform cameraTransform)
        {
            controls.SetCamTransform(cameraTransform);
            controls.enabled = true;
            areControlsEnabled = true;
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
        {
            ProcessEvent(MouseDrag);
        }

        void ProcessEvent(Signal<CharacterView> signal)
        {
            if (!LeanTouch.PointOverGui(Input.mousePosition))
            {
                signal.Dispatch(this);
            }
        }
        void FixedUpdate()
        {
            if (areControlsEnabled)
            {
                var horizontal = JoystickInput.Horizontal != 0
                    ? JoystickInput.Horizontal
                    : Input.GetAxis("Horizontal");
            
                var vertical = JoystickInput.Vertical != 0
                    ? JoystickInput.Vertical
                    : Input.GetAxis("Vertical");
                
                Debug.Log(horizontal);
                Debug.Log(vertical);

                move = vertical * Vector3.forward + horizontal * Vector3.right;
                character.Move(move, false, false);
            }
        }
    }
}