using System;
using UnityEngine;

namespace Assets.Scriptes.Sounds {
    public class AudioActionInvoker : MonoBehaviour {

        public static Action OnBooh;
        public static Action OnZing;
        public static Action OnBoom;

        private void OnCollisionEnter(Collision collision) {
            var tag = collision.gameObject.tag;
            if(tag == Tags.SANDWICH 
                || tag == Tags.GARBAGE) {
                OnBooh?.Invoke();
            } else if (tag == Tags.GARBAGE_METAL) {
                OnZing?.Invoke();
            } else if (tag == Tags.GARBAGE_BRICK) {
                OnBoom?.Invoke();
            }
        }
    }
}