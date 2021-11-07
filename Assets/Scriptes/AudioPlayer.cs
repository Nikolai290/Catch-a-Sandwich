using Assets.Scriptes.Plate;
using Assets.Scriptes.UI.FinishScreen;
using UnityEngine;

namespace Assets.Scriptes {
    public class AudioPlayer : MonoBehaviour {

        [SerializeField] private AudioSource DropOnPlate;
        [SerializeField] private AudioSource FinishGame;

        private void Start() {
            PlateBehaviour.OnSomthingPlantedOnPlate += PlayDropOnPlate;
            FinishScreenBahaviour.OnFinishGame += PlayFinishGame;
        }

        private void PlayDropOnPlate() {
            DropOnPlate.pitch = Random.Range(0.9f, 1.1f);
            DropOnPlate.Play();
        }
        private void PlayFinishGame() {
            FinishGame.pitch = Random.Range(0.9f, 1.1f);
            FinishGame.Play();
        }
    }
}