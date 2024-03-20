using System;
using UnityEngine;

namespace _Game.RSNCore.UI
{
    public class SettingsPanel : Panel
    {
        public GameObject[] vibrationIcons;
        public GameObject[] soundIcons;
        public GameObject[] musicIcons;
        private bool _soundsOn;
        private bool _vibrationsOn;
        private bool _musicOn;

        protected override void Awake()
        {
            base.Awake();
            _soundsOn = Convert.ToBoolean(PlayerPrefs.GetInt("Sounds", 1));
            _musicOn = Convert.ToBoolean(PlayerPrefs.GetInt("Music", 1));
            _vibrationsOn = Convert.ToBoolean(PlayerPrefs.GetInt("Vibrations", 1));
            
            //FeedbackController.Instance.audioSource.enabled = _soundsOn;
            //FeedbackController.Instance.musicSource.enabled = _musicOn;
            RsnHaptic.EnableHaptics(_vibrationsOn);
            ProcessOptions();
        }

        private void ProcessOptions()
        {
            musicIcons[0].SetActive(_musicOn);
            musicIcons[1].SetActive(!_musicOn);
            soundIcons[0].SetActive(_soundsOn);
            soundIcons[1].SetActive(!_soundsOn);
            vibrationIcons[0].SetActive(_vibrationsOn);
            vibrationIcons[1].SetActive(!_vibrationsOn);
        }

        public void ChangeSounds()
        {
            _soundsOn = !_soundsOn;
            PlayerPrefs.SetInt("Sounds", Convert.ToInt32(_soundsOn));
            FeedbackManager.Instance.audioSource.enabled = _soundsOn;
            AudioListener.pause = !_soundsOn;
            ProcessOptions();
        }
        
        public void ChangeMusic()
        {
            _musicOn = !_musicOn;
            PlayerPrefs.SetInt("Music", Convert.ToInt32(_musicOn));
            FeedbackManager.Instance.musicSource.enabled = _musicOn;
            ProcessOptions();
        }

        public void ChangeVibrations()
        {
            _vibrationsOn = !_vibrationsOn;
            RsnHaptic.EnableHaptics(_vibrationsOn);
            PlayerPrefs.SetInt("Vibrations", Convert.ToInt32(_vibrationsOn));
            ProcessOptions();
        }
    }
}