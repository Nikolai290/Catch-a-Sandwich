using System;
using UnityEngine;

namespace Assets.Scriptes.Sandwich {
    public class BreadBehaviour : MonoBehaviour {

        public Action<bool> OnCollisionPlate;
        public Action<bool> OnCollisionFloor;

        private void OnTriggerEnter(Collider other) {
            if (Tags.IfPlate(other.gameObject.tag)) {
                OnCollisionPlate?.Invoke(true);
            }
            if (Tags.IfFloor(other.gameObject.tag)) {
                OnCollisionFloor?.Invoke(true);
            }
        }

        private void OnTriggerExit(Collider other) {
            if (Tags.IfPlate(other.gameObject.tag)) {
                OnCollisionPlate?.Invoke(false);
            }

        }
    }
}