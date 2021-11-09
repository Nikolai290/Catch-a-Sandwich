using UnityEngine;

namespace Assets.Scriptes.UI.MainMenu {
    [CreateAssetMenu(fileName = "MenuParams", menuName = "MenuParams", order = 0)]
    public class MenuParams : ScriptableObject {
        public float menuCameraSize;
        public float gameCameraSize;
        public Vector3 menuCameraPosition;
        public Vector3 gameCameraPosition;
    }
}