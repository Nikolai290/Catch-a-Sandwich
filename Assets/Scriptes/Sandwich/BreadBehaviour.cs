using System;
using UnityEngine;

namespace Assets.Scriptes.Sandwich {
    public class BreadBehaviour : MonoBehaviour {

        public Action<bool> OnCollisionPlateOrFloor;

        private void OnTriggerEnter(Collider other) {
            if (Tags.IfPlate(other.gameObject.tag)) {
                OnCollisionPlateOrFloor?.Invoke(true);
            } 

        }

        private void OnTriggerExit(Collider other) {
            if (Tags.IfPlateOrFloor(other.gameObject.tag)) {
                OnCollisionPlateOrFloor?.Invoke(false);
            }

        }
    }
}