using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ServiceLocator.UI
{
    public class MonkeyImageHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform rectTransform;
        private Image monkeyImage;
        private MonkeyCellController owner;

        private Sprite spriteToSet;
        private Vector2 originalAnchoredPosition;
        private Vector3 originalPosition;

        private Canvas canvas;
        public void ConfigureImageHandler(Sprite spriteToSet, MonkeyCellController owner, Canvas canvas)
        {
            this.spriteToSet = spriteToSet;
            this.owner = owner;
            this.canvas = canvas;
        }

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            monkeyImage = GetComponent<Image>();
            monkeyImage.sprite = spriteToSet;
            originalPosition = rectTransform.localPosition;
            originalAnchoredPosition = rectTransform.anchoredPosition;
        }

        public void OnPointerDown(PointerEventData eventData) => monkeyImage.color = new Color(1, 1, 1, 0.6f);

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / this.canvas.scaleFactor;
            owner.MonkeyDraggedAt(eventData.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            ResetMonkeyImage();
            owner.MonkeyDroppedAt(eventData.position);
        }

        private void ResetMonkeyImage()
        {
            monkeyImage.color = new Color(1, 1, 1, 1f);
            rectTransform.anchoredPosition = originalAnchoredPosition;
            rectTransform.localPosition = originalPosition;
            GetComponent<LayoutElement>().enabled = false;
            GetComponent<LayoutElement>().enabled = true;
        }
    }
}