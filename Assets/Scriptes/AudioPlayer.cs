using Assets.Scriptes.Plate;
using Assets.Scriptes.UI.FinishScreen;
using UnityEngine;

namespace Assets.Scriptes {
    public class AudioPlayer : MonoBehaviour {

        [SerializeField] private AudioSource[] DropOnPlate;
        [SerializeField] private AudioSource[] FinishGame;

        private void Start() {
            PlateBehaviour.OnSomthingPlantedOnPlate += PlayDropOnPlate;
            FinishScreenBahaviour.OnFinishGame += PlayFinishGame;
            FloorBehaviour.OnDropToFloor += PlayDropOnPlate;
        }

        private void PlayDropOnPlate() {
            var voice = DropOnPlate[Random.Range(0, DropOnPlate.Length)];
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