using UnityEngine;

namespace Assets.Scriptes.UI {
    public class UiActionHandlers : MonoBehaviour {
        private bool pause;


        [SerializeField] private GameObject InGameUi;
        [SerializeField] private GameObject PauseMenu;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                EscapeMenuHandler();
            }
        }

        public void EscapeMenuHandler() {
            if (pause) {
                ResumeButtonClickHandler();
                InGameUi.SetActive(true);
                PauseMenu.SetActive(false);
            } else {
                PauseButtonClickHandler();
                InGameUi.SetActive(false);
                PauseMenu.SetActive(true);
            }
        }

        public void PauseButtonClickHandler() {
            pause = true;
            Time.timeScale = 0;
        }

        public void ResumeButtonClickHandler() {
            pause = false;
            Time.timeScale = 1;
        }

        public void ToMainMenuButtonClickHandler() {
            pause = false;
            Time.timeScale = 1;
        }

        public void ExitApplicationHandler() {
            Application.Quit();
        }
    }
}