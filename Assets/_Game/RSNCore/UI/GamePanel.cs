using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.RSNCore.UI
{
    public class GamePanel : Panel
    {
        [SerializeField] private Image levelBackground;
        [SerializeField] private Image settingsButton;
        
        public override void ShowPanel()
        {
            base.ShowPanel();
            var currencyRect = levelBackground.rectTransform;
            var settingsRect = settingsButton.rectTransform;
            currencyRect.DOAnchorPosY(110f, 0.5f).From().SetEase(Ease.OutBounce);
            settingsRect.DOAnchorPosX(-110f, 0.5f).From().SetEase(Ease.OutBounce);
        }
    }
}