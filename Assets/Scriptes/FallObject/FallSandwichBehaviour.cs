using System.Collections;
using UnityEngine;

namespace Assets.Scriptes.FallObject {
    public class FallSandwichBehaviour : FallObjectBehaviour {


        [SerializeField] private GameObject liver;


        private void OnCollisionEnter(Collision collision) {
            rb.useGravity = true;
            liver.AddComponent<Rigidbody>();
            liver.transform.SetParent(null);
        }
    }
}