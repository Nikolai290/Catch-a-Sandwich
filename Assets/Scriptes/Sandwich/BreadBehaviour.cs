using System;
using UnityEngine;

namespace Assets.Scriptes.Sandwich {
    public class BreadBehaviour : MonoBehaviour {

        public Action<bool> OnCollisionPlate;
        public Action OnCollisionFloor;

        private void OnTriggerEnter(Collider other) {
            if (Tags.IfPlate(other.gameObject.tag)) {
                OnCollisionPlate?.Invoke(true);
            }
            if (Tags.IfFloor(other.gameObject.tag)) {
                OnCollisionFloor?.Invoke();
            }

        }

        private void OnTriggerExit(Collider other) {
            if (Tags.IfPlate(other.gameObject.tag)) {
                OnCollisionFloor?.Invoke();
            }

        }
    }
}