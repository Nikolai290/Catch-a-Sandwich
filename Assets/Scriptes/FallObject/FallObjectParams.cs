using UnityEngine;

namespace Assets.Scriptes.FallObject {
    [CreateAssetMenu(fileName = "FallObject01", menuName = "SandwichGame/FallObjectParams", order = 0)]
    public class FallObjectParams : ScriptableObject {
        [Header("Параметры вращения")]
        public bool xRotate, yRotate, zRotate;
        public bool randomTorque;
        public float maxTorque;
        public float minTorque;
        public Vector3 Torque;

        [Header("Параметры скорости падения")]
        public bool randomFallSpeed;
        public float maxFallSpeed;
        public float minFallSpeed;
        public float fallSpeed;

        [Header("Повышение уровня сложности")]
        public int torqueLevelUpStep;
        public int fallSpeedLevelUpStep;
    }
}