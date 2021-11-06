using System;
using UnityEngine;

namespace Assets.Scriptes.Garbage {
    public class GarbageBehaviour : MonoBehaviour {

        public Action<bool> OnCollisionPlateOrFloor;

        private void OnTriggerEnter(Collider other) {
            if (Tags.IfPlateOrFloor(other.gameObject.tag)) {
                OnCollisionPlateOrFloor?.Invoke(true);
            }
        }
    }
}