using Assets.Scriptes.Spawner;
using UnityEngine;

namespace Assets.Scriptes.UI.MainMenu {
    public class MenuGameMachine : MonoBehaviour {

        [SerializeField] private SpawnerBehaviour spawner;
        [SerializeField] private BackgroundBehaviour background;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private GameObject MainMenu;
        [SerializeField] private MenuParams menuParams;

        [SerializeField] private GameObject gamePreset;

        private GameObject sandwichMenu;

        private void Start() {
            gamePreset.SetActive(false);
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
            gamePreset.SetActive(false);
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
            gamePreset.SetActive(true);
        }
    }
}