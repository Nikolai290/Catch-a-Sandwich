using System.Collections;
using UnityEngine;

namespace Assets.Scriptes.FallObject {
    public class StayOnPlateAcceptor : MonoBehaviour {
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