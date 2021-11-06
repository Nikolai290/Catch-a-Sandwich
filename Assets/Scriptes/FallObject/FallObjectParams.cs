using UnityEngine;

namespace Assets.Scriptes.FallObject {
    [CreateAssetMenu(fileName = "FallObject01", menuName = "FallObjectParams", order = 0)]
    public class FallObjectParams : ScriptableObject {
        public bool xRotate, yRotate, zRotate;
        public bool randomTorque;
        public float maxTorque;
        public float minTorque;
        public Vector3 Torque;

        public bool randomFallSpeed;
        public float maxFallSpeed;
        public float minFallSpeed;
        public float fallSpeed;

    }
}