using UnityEngine;

namespace Assets.Scriptes.FallObject {
    public class FallObjectBehaviour : MonoBehaviour {

        [SerializeField] private FallObjectParams fallObjcetParams;

        private Rigidbody rb;

        private void Start() {
            var fallSpeed = fallObjcetParams.fallSpeed;
            if (fallObjcetParams.randomFallSpeed) {
                fallSpeed = Random.Range(fallObjcetParams.minFallSpeed, fallObjcetParams.maxFallSpeed);
            }
            var torque = fallObjcetParams.Torque;
            if (fallObjcetParams.randomTorque) {
                torque = Random.Range(fallObjcetParams.minTorque, fallObjcetParams.maxTorque);
            }

            rb = GetComponent<Rigidbody>();
            rb.AddRelativeTorque(
                Random.Range(0f, 1f) > 0.5f ? torque : -torque,
                0f,
                0f
            );
            rb.AddForce(Vector3.down * fallSpeed);
        }

        private void OnCollisionEnter(Collision collision) {
            rb.useGravity = true;
        }

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.tag == Tags.PLATE_ACCEPTOR) {
                transform.parent = other.transform;
            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.gameObject.tag == Tags.PLATE_ACCEPTOR) {
                transform.parent = null;
            }
        }
    }
}