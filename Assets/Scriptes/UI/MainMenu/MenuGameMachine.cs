using Assets.Scriptes.Spawner;
using UnityEngine;

namespace Assets.Scriptes.UI.MainMenu {
    public class MenuGameMachine : MonoBehaviour {

        [SerializeField] SpawnerBehaviour spawner;
        [SerializeField] BackgroundBehaviour background;
        [SerializeField] Camera mainCamera;
        [SerializeField] GameObject MainMenu;
        private float menuCameraSize = 2;
        private float gameCameraSize = 9;
        private Vector3 menuCameraPosition = new Vector3(0, 31, -15);
        private Vector3 gameCameraPosition = new Vector3(0, 5, -27);

        private GameObject sandwichMenu;

        private void Start() {
            MainMenu.SetActive(true);
            ShowMenu();
        }

        public void ShowMenu() {
            if(sandwichMenu is null) {
                sandwichMenu = spawner.SpawnSandwich();
            } else {
                sandwichMenu.SetActive(true);
            }
            background.gameObject.SetActive(true);
            background.moving = true;
            mainCamera.orthographicSize = menuCameraSize;
            mainCamera.transform.position = menuCameraPosition;
        }

        public void ToGame() {
            mainCamera.orthographicSize = gameCameraSize;
            mainCamera.transform.position = gameCameraPosition;
            sandwichMenu.SetActive(false);
            background.gameObject.SetActive(false);
        }
    }
}