using System.Collections;
using UnityEngine;

namespace Assets.Scriptes {
    public class DeleteZone : MonoBehaviour {


        private void OnTriggerEnter(Collider other) {
            Destroy(other.gameObject);
        }

        private void OnCollisionEnter(Collision collision) {
            StartCoroutine(Deleting(collision.gameObject));
        }

        private IEnumerator Deleting(GameObject obj) {
            yield return new WaitForSeconds(1f);
            Destroy(obj);
        }
    }
}