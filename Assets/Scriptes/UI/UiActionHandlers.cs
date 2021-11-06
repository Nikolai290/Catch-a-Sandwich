using Assets.Scriptes.Game;
using UnityEngine;

namespace Assets.Scriptes.UI {
    public class UiActionHandlers : MonoBehaviour {
        private bool pause;

        [SerializeField] private GameObject InGameUi;
        [SerializeField] private GameObject PauseMenu;
        [SerializeField] private GameMachineBehaviour gameMachine;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                EscapeMenuHandler();
            }
        }

        public void EscapeMenuHandler() {
            if (gameMachine.playGame) {
                if (pause) {
                    ResumeButtonClickHandler();
                    InGameUi.SetActive(true);
                    PauseMenu.SetActive(false);
                } else {
                    PauseButtonClickHandler();
                    InGameUi.SetActive(false);
                    PauseMenu.SetActive(true);
                }
            } else {
                ExitApplicationHandler();
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