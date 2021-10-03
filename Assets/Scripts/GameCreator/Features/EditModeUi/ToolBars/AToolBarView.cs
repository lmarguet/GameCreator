using Signals;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Features.EditModeUi.ToolBars
{
    public abstract class AToolBarView : MonoBehaviour
    {
        public readonly Signal OnClose = new Signal();

        [SerializeField] Button closeButton;
        [SerializeField] CanvasGroup canvasGroup;

        public abstract ToolBarType Type { get; }

        void Awake()
        {
            closeButton.onClick.AddListener(Close);
        }

        public void Show()
        {
            canvasGroup.alpha = 1;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            canvasGroup.alpha = 0;
            gameObject.SetActive(false);
        }

        protected void Close()
        {
            DoCloseInternal();
            Hide();
            OnClose.Dispatch();
        }

        protected virtual void DoCloseInternal()
        {
        }
    }
}