using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Michsky.UI.ModernUIPack
{
    public class AnimatedIconHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [Header("Settings")]
        public PlayType playType;
        public Animator iconAnimator;

        public UnityEvent onFunction;
        public UnityEvent offFunction;
        
        bool isClicked;

        public enum PlayType
        {
            CLICK,
            ON_POINTER_ENTER
        }

        void Start()
        {
            if (iconAnimator == null)
                iconAnimator = gameObject.GetComponent<Animator>();
        }

        public void ClickEvent()
        {
            if (isClicked == true)
            {
                iconAnimator.Play("Out");
                offFunction.Invoke();
                isClicked = false;
            }

            else
            {
                iconAnimator.Play("In");
                onFunction.Invoke();
                isClicked = true;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ClickEvent();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (playType == PlayType.ON_POINTER_ENTER)
                iconAnimator.Play("In");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (playType == PlayType.ON_POINTER_ENTER)
                iconAnimator.Play("Out");
        }
    }
}