using _Game.RSNCore.Extensions;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace _Game.RSNCore.UI
{
    public abstract class Panel : MonoBehaviour
    {
        [SerializeField] private bool hasLevelText;
        
        [ShowIf("hasLevelText"),SerializeField] protected TMP_Text levelText;

        protected virtual void Awake()
        {
            
        }
        
        protected virtual void Start()
        {
            
        }

        [Button]
        public virtual void ShowPanel()
        {
            if (hasLevelText)
            {
                var level = PlayerPrefs.GetInt("Level",1).ToString();
                levelText.text = $"Level {level}";
            }
            
            this.Show();
        }

        public virtual void HidePanel()
        {
            this.Hide();
        }
    }
}