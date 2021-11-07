using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scriptes.UI {
    public class HideText : MonoBehaviour {

        private Text text;
        private void Start() {
            text = GetComponentInChildren<Text>();
        }
        public void HideTextButtonActionHandler() {
            text.enabled = !text.enabled;
        }
    }
}