using System;
using UnityEngine;

namespace Assets.Scriptes.Plate {
    public class PlateBehaviour : MonoBehaviour {

        public static Action OnSomthingPlantedOnPlate;

        private void OnCollisionEnter(Collision collision) {
            OnSomthingPlantedOnPlate?.Invoke();
        }
    }
}