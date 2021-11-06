using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scriptes.Garbage {
    public class GarbageBehaviour : MonoBehaviour {

        public static Action OnCollisionPlate;
        public float collisionStayTimeout;

        private bool lose = false;

        private void OnTriggerEnter(Collider other) {
            if (Tags.IfPlateAcceptor(other.gameObject.tag)) {
                Lose();
            }
        }

        private void Lose() {
            if (lose) return;
            lose = true;
            OnCollisionPlate?.Invoke();
            StartCoroutine(Destroing());
        }

        private IEnumerator Destroing() {
            yield return new WaitForSeconds(collisionStayTimeout);
            Destroy(gameObject);
        }
    }
}