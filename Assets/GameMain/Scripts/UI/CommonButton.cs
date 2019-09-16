using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ArrowPlay
{
    public class CommonButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        private const float FadeTime = 0.3f;
        private const float OnHoverAlpha = 0.7f; 
        private const float OnClickAlpha = 0.6f;

        [NonSerialized]
        public UnityEvent m_OnHover = null;

        [NonSerialized]
        public UnityEvent m_OnClick = null;

        private CanvasGroup m_CanvasGroup = null;

        private void Awake()
        {
            m_CanvasGroup = gameObject.GetOrAddComponent<CanvasGroup>();
        }

        private void OnDisable()
        {
            m_CanvasGroup.alpha = 1f;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }

            StopAllCoroutines();
            StartCoroutine(m_CanvasGroup.FadeToAlpha(OnHoverAlpha, FadeTime));
            if (m_OnHover != null)
                m_OnHover.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }

            StopAllCoroutines();
            StartCoroutine(m_CanvasGroup.FadeToAlpha(1f, FadeTime));
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }

            m_CanvasGroup.alpha = OnClickAlpha;
            if (m_OnClick != null)
                m_OnClick.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }

            m_CanvasGroup.alpha = OnHoverAlpha;
        }

        public static CommonButton Get(GameObject obj)
        {
            var commonButton = obj.GetComponent<CommonButton>();
            if (!commonButton)
            {
                commonButton = obj.AddComponent<CommonButton>();
            }
            return commonButton;
        }
    }
}
