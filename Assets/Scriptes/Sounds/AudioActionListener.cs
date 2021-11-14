using Assets.Scriptes.UI;
using Assets.Scriptes.UI.FinishScreen;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scriptes.Sounds {
    public class AudioActionListener : MonoBehaviour {

        [SerializeField] private AudioSource[] BoohSources;
        [SerializeField] private AudioSource[] BoomSources;
        [SerializeField] private AudioSource[] ZingSources;
        [SerializeField] private AudioSource[] FinishGame;

        [SerializeField] private AudioSource[] ButtonDownSources;
        [SerializeField] private AudioSource[] ButtonUpSources;

        [SerializeField] private AudioSource[] musicSorces;

        private List<AudioSource> effectSources;
        private void Start() {
            AudioActionInvoker.OnBooh+= PlayBooh;
            FinishScreenBahaviour.OnFinishGame += PlayFinishGame;
            AudioActionInvoker.OnBoom += PlayBoom;
            AudioActionInvoker.OnZing += PlayZing;

            ButtonBehaviour.onButtonDown += PlayButtonDown;
            ButtonBehaviour.onButtonUp += PlayButtonUp;

            effectSources = new List<AudioSource>();
            effectSources.AddRange(BoohSources);
            effectSources.AddRange(BoomSources);
            effectSources.AddRange(ZingSources);
            effectSources.AddRange(FinishGame);
            effectSources.AddRange(ButtonUpSources);
            effectSources.AddRange(ButtonDownSources);
        }

        public void SetEffectsVolume(float volume) {
            foreach (var source in effectSources) {
                source.volume = volume;
            }
        }

        public void SetMusicVolume(float volume) {
            foreach (var source in musicSorces) {
                source.volume = volume;
            }
        }

        public void Mute(bool mute) {
            foreach (var source in musicSorces) {
                source.mute = mute;
            }
            foreach (var source in effectSources) {
                source.mute = mute;
            }
        }

        private void PlayZing() {
            if (ZingSources.Length == 0) return;
            var voice = ZingSources[Random.Range(0, ZingSources.Length)];
            voice.pitch = Random.Range(0.9f, 1.1f);
            voice.Play();
        }

        private void PlayBoom() {
            if (BoomSources.Length == 0) return;
            var voice = BoomSources[Random.Range(0, BoomSources.Length)];
            voice.pitch = Random.Range(0.9f, 1.1f);
            voice.Play();
        }

        private void PlayBooh() {
            if (BoohSources.Length == 0) return;
            var voice = BoohSources[Random.Range(0, BoohSources.Length)];
            voice.pitch = Random.Range(0.9f, 1.1f);
            voice.Play();
        }
        private void PlayFinishGame() {
            if (FinishGame.Length == 0) return;
            var voice = FinishGame[Random.Range(0, FinishGame.Length)];
            voice.pitch = Random.Range(0.9f, 1.1f);
            voice.Play();
        }

        private void PlayButtonDown() {
            if (ButtonDownSources.Length == 0) return;
            var voice = ButtonDownSources[Random.Range(0, ButtonDownSources.Length)];
            voice.pitch = Random.Range(0.9f, 1.1f);
            voice.Play();
        }

        private void PlayButtonUp() {
            if (ButtonUpSources.Length == 0) return;
            var voice = ButtonUpSources[Random.Range(0, ButtonUpSources.Length)];
            voice.pitch = Random.Range(0.9f, 1.1f);
            voice.Play();
        }
    }
}