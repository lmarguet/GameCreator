using Lean.Touch;
using Signals;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace GameCreator.Features.Characters
{
    public class CharacterView : SavableView
    {
        public readonly Signal<CharacterView> MouseUp = new Signal<CharacterView>();
        public readonly Signal<CharacterView> MouseDown = new Signal<CharacterView>();
        public readonly Signal<CharacterView> MouseDrag = new Signal<CharacterView>();

        [SerializeField] bool areControlsEnabled;
        [SerializeField] GameObject playerMarker;

        Animator animator;
        Vector3 screenPoint;
        Vector3 offset;
        ThirdPersonCharacter character;
        Vector3 move;

        public CharacterType CharacterType { get; private set; }

        public bool IsSelected { get; set; }

        void Awake()
        {
            animator = GetComponent<Animator>();
            character = GetComponent<ThirdPersonCharacter>();
            playerMarker.SetActive(false);
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
            areControlsEnabled = false;
            UpdatePlayerMarkerVisibility();
        }

        void UpdatePlayerMarkerVisibility()
        {
            playerMarker.SetActive(CharacterType == CharacterType.Player);
        }

        public void EnableControls()
        {
            areControlsEnabled = true;
            playerMarker.SetActive(false);
        }

        public void SetType(CharacterType type)
        {
            CharacterType = type;
            UpdatePlayerMarkerVisibility();
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

                move = vertical * Vector3.forward + horizontal * Vector3.right;
                character.Move(move, false, false);
            }
        }
    }
}