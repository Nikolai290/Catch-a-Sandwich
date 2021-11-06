using UnityEngine;

namespace Assets.Scriptes {
    public class GameMenu : MonoBehaviour {

        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }
    }
}