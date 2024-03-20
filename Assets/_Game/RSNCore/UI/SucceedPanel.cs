using DG.Tweening;
using JoshH.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.RSNCore.UI
{
    public class SucceedPanel : Panel
    {
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private UIGradient gradientImage;
        [SerializeField] private TMP_Text rewardText;
        
        public override void ShowPanel()
        {
            base.ShowPanel();
            DOVirtual.Float(0f, 1f, 1f, value => gradientImage.Intensity = value);
            nextLevelButton.onClick.AddListener(GameManager.Instance.OnLevelCompleteButtonClick);
            rewardText.DOText(GameManager.Instance.CalculatePossibleIncome().ToString(), 0.5f, true, ScrambleMode.Numerals);
        }
    }
}