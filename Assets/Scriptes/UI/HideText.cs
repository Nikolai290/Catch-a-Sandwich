using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scriptes.UI {
    public class HideText : MonoBehaviour {

        private Text text;
        private void Start() {
            text = GetComponent<Text>();
        }
        private void OnMouseUp() {
            text.enabled = !text.enabled;
        }
    }
}