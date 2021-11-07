using UnityEngine;

namespace Assets.Scriptes.UI.MainMenu {
    [CreateAssetMenu(fileName = "MenuSandwichParams", menuName = "MenuSandwichParams", order = 0)]
    public class MenuSandwichParams : ScriptableObject {
        public bool xRotate, yRotate, zRotate;
        public bool randomTorque;
        public float maxTorque;
        public float minTorque;
        public Vector3 Torque;
    }
}