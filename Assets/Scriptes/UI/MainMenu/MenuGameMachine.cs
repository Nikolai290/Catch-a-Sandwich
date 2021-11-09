using Assets.Scriptes.Spawner;
using UnityEngine;

namespace Assets.Scriptes.UI.MainMenu {
    public class MenuGameMachine : MonoBehaviour {

        [SerializeField] SpawnerBehaviour spawner;
        [SerializeField] BackgroundBehaviour background;
        [SerializeField] Camera mainCamera;
        [SerializeField] GameObject MainMenu;
        [SerializeField] MenuParams menuParams;

        private GameObject sandwichMenu;

        private void Start() {
            MainMenu.SetActive(true);
            ShowMenu();
        }

        public void ShowMenu() {
            Time.timeScale = 1;
            if (sandwichMenu is null) {
                sandwichMenu = spawner.SpawnSandwich();
            } else {
                sandwichMenu.SetActive(true);
            }
            background.gameObject.SetActive(true);
            background.moving = true;
            mainCamera.orthographicSize = menuParams.menuCameraSize;
            mainCamera.transform.position = menuParams.menuCameraPosition;
        }

        public void ToGame() {
            Time.timeScale = 1;
            mainCamera.orthographicSize = menuParams.gameCameraSize;
            mainCamera.transform.position = menuParams.gameCameraPosition;
            sandwichMenu.SetActive(false);
            background.gameObject.SetActive(false);
        }
    }
}