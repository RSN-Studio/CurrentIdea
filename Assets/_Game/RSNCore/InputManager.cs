using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.RSNCore
{
    public class InputManager : Singleton<InputManager>
    {
        [field: SerializeField] public Joystick Joystick { get; private set; }
        private bool _isHolding;

        protected override void Start()
        {
            base.Start();
            AddListeners();
        }

        private void Update()
        {
            if (_isHolding)
            {
                Debug.Log(Joystick.Direction);
            }
        }

        private void AddListeners()
        {
            InputPanel.Instance.onPointerDownFullInfo.AddListener(OnPointerDown);
            InputPanel.Instance.onDragFullInfo.AddListener(OnDrag);
            InputPanel.Instance.onPointerUpFullInfo.AddListener(OnPointerUp);
        }

        public void RemoveAllListeners()
        {
            InputPanel.Instance.onDragFullInfo.RemoveAllListeners();
            InputPanel.Instance.onDragFullInfo.RemoveAllListeners();
            InputPanel.Instance.onPointerUpFullInfo.RemoveAllListeners();
        }

        private void OnPointerDown(PointerEventData eventData)
        {
            _isHolding = true;
            Joystick.OnPointerDown(eventData);
        }

        private void OnDrag(PointerEventData eventData)
        {
            Joystick.OnDrag(eventData);
        }
        
        private void OnPointerUp(PointerEventData eventData)
        {
            _isHolding = false;
            Joystick.OnPointerUp(eventData);
        }
    }
}
