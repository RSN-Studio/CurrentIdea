using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.RSNCore.Extensions
{
    [RequireComponent(typeof (CanvasScaler))]
    public class CanvasReferenceScaler : MonoBehaviour
    {
        private CanvasScaler canvasScaler;
        [Title("Canvas Reference Setup")]
        [SerializeField]
        private Vector2 mainReferenceResolution = new Vector2(1536f, 2048f);
        [SerializeField]
        [Range(0.0f, 1f)]
        private float matchWidthOrHeight;
        [SerializeField]
        private CanvasScaler.ScaleMode uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

        private void Awake()
        {
            canvasScaler = GetComponent<CanvasScaler>();
            AdjustReferenceResolution();
        }

        private void AdjustReferenceResolution()
        {
            if (!(bool) (Object) canvasScaler) return;
            canvasScaler.uiScaleMode = uiScaleMode;
            canvasScaler.matchWidthOrHeight = matchWidthOrHeight;
            canvasScaler.referenceResolution = new Vector2((float) (mainReferenceResolution.x * (Screen.width * 1.0 / Screen.height) / 0.4618000090122223), mainReferenceResolution.y);
        }
    }
}