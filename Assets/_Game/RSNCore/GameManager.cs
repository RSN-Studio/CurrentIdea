using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.RSNCore
{
    public class GameManager : Singleton<GameManager>
    {
        public enum GameState
        {
            Started,
            Playing,
            Failed,
            Succeed
        }

        public GameState gameState;

        [Title("Player Settings", titleAlignment: TitleAlignments.Centered)]
        [Title("Game Settings", titleAlignment: TitleAlignments.Centered), Space(30)]
        [Title("Level Settings Settings", titleAlignment: TitleAlignments.Centered), Space(30)]
        public List<Level> levels;

        public Level currentLevel;

        [Title("Current Session Data", titleAlignment: TitleAlignments.Centered), Space(30)]
        public int currency;


        protected override void Awake()
        {
            //var tutorialPlayed = PlayerPrefs.GetInt("Tutorial", 0);

            gameState = GameState.Started;
            Application.targetFrameRate = 60;
            currency = PlayerPrefs.GetInt("Currency");
            DOTween.SetTweensCapacity(500, 100);

            var playedLevelCount = PlayerPrefs.GetInt("Level");
            //Analytics.Instance.SendLevelStart(playedLevelCount + 1);
            var totalLevelCount = levels.Count;
            var minLevel = Mathf.Min(3, playedLevelCount);
            var targetIdx = playedLevelCount > totalLevelCount - 1
                ? Random.Range(minLevel, totalLevelCount)
                : playedLevelCount;
        }

        protected override void Start()
        {
            base.Start();
            Started();
        }

        private void Started()
        {
            gameState = GameState.Playing;
            UIManager.Instance.Playing();
        }

        public void Failed()
        {
            if (gameState == GameState.Failed) return;
            //Analytics.Instance.SendLevelComplete(PlayerPrefs.GetInt("Level") + 1);
            gameState = GameState.Failed;
            RsnHaptic.Failed();
            UIManager.Instance.Failed();
            //this.Delay(() => SfxManager.Instance.PlaySfx(3, true), 1f);
        }

        public void Succeed()
        {
            if (gameState == GameState.Succeed) return;

            //UIManager.Instance.moneyRewardText.text = possibleRewardOfLevel.ToString();

            gameState = GameState.Succeed;
            RsnHaptic.Success();
            UIManager.Instance.Succeed();
            InputManager.Instance.RemoveAllListeners();

            //this.Delay(() => SfxManager.Instance.PlaySfx(2, true), 1f);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                LoadLevel();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Succeed();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                Failed();
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                PlayerPrefs.SetInt("PlayedLevelCount", PlayerPrefs.GetInt("PlayedLevelCount") + 1);
                LoadLevel();
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                PlayerPrefs.SetInt("Level", Mathf.Max(0, PlayerPrefs.GetInt("Level") - 1));
                PlayerPrefs.SetInt("PlayedLevelCount", PlayerPrefs.GetInt("PlayedLevelCount") - 1);
                LoadLevel();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                UpdateCurrency(100);
            }
        }

        private void LoadLevel()
        {
            DOTween.KillAll(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public int CalculatePossibleIncome()
        {
            return 0;
        }

        public void OnLevelFailedButtonClick()
        {
            //UIManager.Instance.CoinAnimation();
            //Analytics.Instance.SendLevelFailed(PlayerPrefs.GetInt("Level") + 1);

            DOVirtual.DelayedCall(0.5f, LoadLevel);
        }

        public void OnLevelCompleteButtonClick()
        {
            //UIManager.Instance.CoinAnimation();
            //Analytics.Instance.SendLevelComplete(PlayerPrefs.GetInt("Level") + 1);

            UpdateCurrency(CalculatePossibleIncome());
            PlayerPrefs.SetInt("PlayedLevelCount", PlayerPrefs.GetInt("PlayedLevelCount") + 1);
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            DOVirtual.DelayedCall(0.5f, LoadLevel);
        }

        public void UpdateCurrency(int value)
        {
            currency += value;
            PlayerPrefs.SetInt("Currency", currency);
            UIManager.Instance.VisualiseMoney(currency - value, value);
        }

        public void RetryWithCoin()
        {
            if (gameState == GameState.Failed)
            {
                gameState = GameState.Playing;
                UIManager.Instance.Playing();
                //Analytics.Instance.SendLevelComplete(PlayerPrefs.GetInt("Level") + 1);
                UpdateCurrency(-100);
            }
        }

        private void OnApplicationQuit()
        {
            DOTween.KillAll(true);
        }
    }
}