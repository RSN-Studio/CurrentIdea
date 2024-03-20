using System.Collections.Generic;
using System.Linq;
using _Game.RSNCore.Extensions;
using _Game.RSNCore.UI;
using DG.Tweening;
using UnityEngine;

namespace _Game.RSNCore
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private List<Panel> panels = new List<Panel>();
        [SerializeField] private GamePanel gamePanel;
        [SerializeField] private FailedPanel failedPanel;
        [SerializeField] private SucceedPanel succeedPanel;
        [SerializeField] private TutorialPanel tutorialPanel;
        [SerializeField] private MoneyPanel moneyPanel;

        protected override void Awake()
        {
            base.Awake();
            HideAllPanels();
        }

        public void Playing()
        {
            gamePanel.ShowPanel();
            moneyPanel.ShowPanel();
        }

        public void Succeed()
        {
            HideAllPanels();
            succeedPanel.ShowPanel();
        }

        public void Failed()
        {
            HideAllPanels();
            failedPanel.ShowPanel();
        }

        private void HideAllPanels()
        {
            panels.ForEach((panel => panel.Hide()));
        }

        public void VisualiseMoney(int start, int value, float time = 0.1f)
        {
           moneyPanel.VisualiseMoney(start,value,time);
        }
    }
}
