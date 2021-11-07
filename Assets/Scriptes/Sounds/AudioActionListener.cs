using Assets.Scriptes.UI.FinishScreen;
using UnityEngine;

namespace Assets.Scriptes.Sounds {
    public class AudioActionListener : MonoBehaviour {

        [SerializeField] private AudioSource[] BoohSources;
        [SerializeField] private AudioSource[] BoomSources;
        [SerializeField] private AudioSource[] ZingSources;
        [SerializeField] private AudioSource[] FinishGame;

        private void Start() {
            AudioActionInvoker.OnBooh+= PlayBooh;
            FinishScreenBahaviour.OnFinishGame += PlayFinishGame;
            AudioActionInvoker.OnBoom += PlayBoom;
            AudioActionInvoker.OnZing += PlayZing;
        }

        private void PlayZing() {
            var voice = ZingSources[Random.Range(0, ZingSources.Length)];
            voice.pitch = Random.Range(0.9f, 1.1f);
            voice.Play();
        }

        private void PlayBoom() {
            var voice = BoomSources[Random.Range(0, BoomSources.Length)];
            voice.pitch = Random.Range(0.9f, 1.1f);
            voice.Play();
        }

        private void PlayBooh() {
            var voice = BoohSources[Random.Range(0, BoohSources.Length)];
            voice.pitch = Random.Range(0.9f, 1.1f);
            voice.Play();
        }
        private void PlayFinishGame() {
            var voice = FinishGame[Random.Range(0, FinishGame.Length)];
            voice.pitch = Random.Range(0.9f, 1.1f);
            voice.Play();
        }

    }
}