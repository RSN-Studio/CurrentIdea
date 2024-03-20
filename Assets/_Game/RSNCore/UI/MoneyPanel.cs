using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.RSNCore.UI
{
    public class MoneyPanel : Panel
    {
        [SerializeField] private TMP_Text currencyText;
        [SerializeField] private Image currencyBackground;

        public override void ShowPanel()
        {
            var currency = PlayerPrefs.GetInt("Currency",0);
            currencyText.text = currency.ToString();
            base.ShowPanel();
            var currencyRect = currencyBackground.rectTransform;
            currencyRect.DOAnchorPosX(currencyRect.rect.width, 0.5f).From().SetEase(Ease.OutBounce);
        }
        public void VisualiseMoney(int start, int value, float time = 0.1f)
        {
            var newValue = start;
            DOTween.Kill(currencyText.gameObject.name);
            DOTween.Kill(currencyText.transform);
            DOTween.To(() => newValue, x => newValue = x, newValue + value, time)
                .OnUpdate(() => currencyText.text = newValue.ToString())
                .OnStart(() => currencyText.transform.DOScale(1.5f, 0.125f))
                .OnComplete(() => currencyText.transform.DOScale(1f, 0.125f))
                .SetId(currencyText.gameObject.name).SetEase(Ease.OutExpo);
        }
    }
}