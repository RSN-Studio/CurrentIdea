using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Game.RSNCore
{
    [RequireComponent(typeof(Image))]
    public class InputPanel : Singleton<InputPanel>, IDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [Space(16f)] 
        [Title("Full Info Events")]
        public PointerEventDataEvent onDragFullInfo = new PointerEventDataEvent();
        public PointerEventDataEvent onPointerDownFullInfo = new PointerEventDataEvent();
        public PointerEventDataEvent onPointerUpFullInfo = new PointerEventDataEvent();
        public PointerEventDataEvent onPointerExitFullInfo = new PointerEventDataEvent();
        
        [Space(16f)]
        [Title("Delta Event")] 
        public PositionEvent onDragDelta = new PositionEvent();

        [Space(16f)] 
        [Title("Position Events")]
        public PositionEvent onDragPosition = new PositionEvent();
        public PositionEvent onPointDownPosition = new PositionEvent();
        public PositionEvent onPointerUpPosition = new PositionEvent();
        public PositionEvent onPointerExitPosition = new PositionEvent();
        
        [Space(16f)] 
        [Title("Pointer Events")] 
        public EmptyEvent onPointerDownEvent = new EmptyEvent();
        public EmptyEvent onPointerUpEvent = new EmptyEvent();
        public EmptyEvent onPointerExitEvent = new EmptyEvent();
        private Image inputImage;

        protected override void Awake() => inputImage = GetComponent<Image>();

        public void OnDrag(PointerEventData eventData)
        {
            onDragDelta?.Invoke(eventData.delta * (1536f / Screen.width));
            onDragPosition?.Invoke(eventData.position * (1536f / Screen.width));
            onDragFullInfo?.Invoke(eventData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            onPointDownPosition?.Invoke(eventData.position * (1536f / Screen.width));
            onPointerDownEvent?.Invoke();
            onPointerDownFullInfo?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onPointerUpPosition?.Invoke(eventData.position * (1536f / Screen.width));
            onPointerUpEvent.Invoke();
            onPointerUpFullInfo?.Invoke(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onPointerExitPosition?.Invoke(eventData.position * (1536f / Screen.width));
            onPointerExitEvent?.Invoke();
            onPointerExitFullInfo?.Invoke(eventData);
        }

        public void Enable() => inputImage.enabled = true;

        public void Disable() => inputImage.enabled = false;
    }

    [Serializable]
    public class PointerEventDataEvent : UnityEvent<PointerEventData>
    {
    }

    [Serializable]
    public class PositionEvent : UnityEvent<Vector2>
    {
    }

    [Serializable]
    public class EmptyEvent : UnityEvent
    {
    }
}