using System;
using UnityEngine;


namespace Assets.Scriptes.Sandwich {
    public class ButterBehaviour : MonoBehaviour {

        public Action<bool> OnCollisionPlateOrFloor;

        private void OnTriggerEnter(Collider other) {
            if (Tags.IfPlateOrFloor(other.gameObject.tag)) {
                OnCollisionPlateOrFloor?.Invoke(true);
            }

            if(other.gameObject.tag != Tags.SANDWICH) {
                gameObject.AddComponent<Rigidbody>();
            }
        }
    }
}