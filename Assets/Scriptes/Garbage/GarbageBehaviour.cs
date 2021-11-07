using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scriptes.Garbage {
    public class GarbageBehaviour : MonoBehaviour {

        public static Action OnCollisionPlate;
        public float collisionStayTimeout;

        private bool destroing = false;

        private void OnTriggerEnter(Collider other) {
            if (Tags.IfPlateAcceptor(other.gameObject.tag)) {
                Lose();
            }
            if (Tags.IfFloor(other.gameObject.tag)) {
                DestoyMe();
            }
        }

        private void Lose() {
            if (destroing) return;
            destroing = true;
            OnCollisionPlate?.Invoke();
            StartCoroutine(Destroing());
        }
        private void DestoyMe() {
            if (destroing) return;
            destroing = true;
            StartCoroutine(Destroing());
        }

        private IEnumerator Destroing() {
            yield return new WaitForSeconds(collisionStayTimeout);
            Destroy(gameObject);
        }
    }
}