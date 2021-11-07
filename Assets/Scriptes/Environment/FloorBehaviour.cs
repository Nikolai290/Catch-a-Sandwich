using System;
using UnityEngine;

namespace Assets.Scriptes {
    public class FloorBehaviour : MonoBehaviour {

        public static Action OnDropToFloor;

        private void OnCollisionEnter(Collision collision) {
            OnDropToFloor?.Invoke();
        }
    }
}