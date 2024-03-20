using DG.Tweening;
using JoshH.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.RSNCore.UI
{
    public class FailedPanel : Panel
    {
        [SerializeField] private Button restartLevelButton;
        [SerializeField] private UIGradient gradientImage;
        
        public override void ShowPanel()
        {
            base.ShowPanel();
            DOVirtual.Float(0f, 1f, 1f, value => gradientImage.Intensity = value);
            restartLevelButton.onClick.AddListener(GameManager.Instance.OnLevelFailedButtonClick);
        }
    }
}