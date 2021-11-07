using UnityEngine;

namespace Assets.Scriptes.FallObject {
    public class FallObjectBehaviour : MonoBehaviour {

        [SerializeField] protected FallObjectParams param;

        protected Rigidbody rb;

        private void Start() {
            var fallSpeed = param.fallSpeed;
            if (param.randomFallSpeed) {
                fallSpeed = Random.Range(param.minFallSpeed, param.maxFallSpeed);
            }
            var torque = param.Torque;
            if (param.randomTorque) {
                torque = new Vector3(
                        param.xRotate ? GetRandomFloat() : 0,
                        param.yRotate ? GetRandomFloat() : 0,
                        param.zRotate ? GetRandomFloat() : 0
                    );
            }
            rb = GetComponent<Rigidbody>();
            rb.AddRelativeTorque(torque);
            rb.AddForce(Vector3.down * fallSpeed);
        }

        public float GetRandomFloat() {
            var torque = Random.Range(param.minTorque, param.maxTorque);
            return Random.Range(0f, 1f) > 0.5f ? torque : -torque;
        }

        private void OnCollisionEnter(Collision collision) {
            rb.useGravity = true;
        }
    }
}