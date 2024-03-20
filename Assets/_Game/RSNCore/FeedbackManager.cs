using System.Collections.Generic;
using System.Linq;
using Lofelt.NiceVibrations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.RSNCore
{
    public class FeedbackManager : Singleton<FeedbackManager>
    {
        [Header("VFX"), Space(50)] 
        public ParticleSystem dummyParticleVFX;

        [SerializeField] private List<ParticleSystem> dummyParticleSystem = new List<ParticleSystem>();

        [Header("SOUND"), Space(50)]
        [SerializeField] private AudioClip levelSucceedSound;
        [SerializeField] private AudioClip levelFailedSound;
        [SerializeField] private AudioClip buttonTapSound;

        [SerializeField] private List<AudioClip> sfx;

        [SerializeField] private float pitchOffset = 0.1f;

        public AudioSource audioSource;
        public AudioSource musicSource;
        private int _lastIdx;

        protected override void Start()
        {
            for (var i = 0; i < 10; i++)
            {
                //dummyParticleSystem.Add(Instantiate(dummyParticleVFX, transform));
            }

            sfx.Add(levelSucceedSound);
            sfx.Add(levelFailedSound);
        }

        public void PlayDummyParticlesOnPosition(Vector3 position)
        {
            var particle = dummyParticleSystem.FirstOrDefault((system => !system.isPlaying));
            if (particle == null) return;
            particle.transform.position = position;
            particle.Play(true);
        }

        public void ResetPitch() => audioSource.pitch = 1f;

        public void PlayButtonSound() => PlaySfx(buttonTapSound);

        /// <summary>
        /// </summary>
        /// <param name="idx">
        /// 0 -> Sound Name Example,
        /// 1 -> Sound Name Example 1 
        /// </param>
        /// 
        public void PlaySfx(int idx, bool reset = false, bool reverse = false)
        {
            if (reset)
            {
                audioSource.pitch = 1f;
            }

            var sound = sfx[idx];

            if (idx == _lastIdx)
            {
                if (reverse)
                {
                    audioSource.pitch -= pitchOffset;
                }
                else
                {
                    audioSource.pitch += pitchOffset;
                }
            }
            else
            {
                audioSource.pitch = 1f;
            }

            _lastIdx = idx;
            audioSource.PlayOneShot(sound);
        }

        public void PlaySfx(AudioClip clip) => audioSource.PlayOneShot(clip);

        [ShowInInspector]
        public void PlayHaptic(HapticPatterns.PresetType type)
        {
            RsnHaptic.PlayHapticPreset(type);
        }

        public void PlayButtonHaptic() => RsnHaptic.LightImpact();
    }
}