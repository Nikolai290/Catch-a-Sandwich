using UnityEngine;

namespace Assets.Scriptes.Plate {
    [CreateAssetMenu(fileName = "PlateParams01", menuName = "SandwichGame/PlateParams", order = 0)]
    public class PlateParams : ScriptableObject {
        public Vector2 MinBorder;
        public Vector2 MaxBorder;
        public float speed;

        public GameObject PlatePrefab;
    }
}