using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scriptes.Sandwich {
    public class SandwichBehaviour : MonoBehaviour {

        public static Action OnScoreUp;
        public static Action OnLosing;

        public float collisionStayTimeout;

        private bool lose = false;
        private bool win = false;

        private bool staying;

        private ButterBehaviour butterBehaviour;
        private BreadBehaviour breadBehaviour;

        private void Start() {
            butterBehaviour = GetComponentInChildren<ButterBehaviour>();
            breadBehaviour = GetComponentInChildren<BreadBehaviour>();
            butterBehaviour.OnCollisionPlateOrFloor += SetLose;
            breadBehaviour.OnCollisionPlateOrFloor += SetWin;
        }

        public void SetLose(bool lose) {
            this.lose = lose;
            StartCoroutine(Losing());

        }

        public void SetWin(bool win) {
            this.win = win;
            if (staying) return;
            staying = true;
            StartCoroutine(Winning());
        }

        private IEnumerator Losing() {
            OnLosing?.Invoke();
            yield return new WaitForSeconds(collisionStayTimeout);
            Destroy(gameObject);
        }
        private IEnumerator Winning() {
            yield return new WaitForSeconds(collisionStayTimeout);
            if(win && !lose) {
                OnScoreUp?.Invoke();
                Destroy(gameObject);
            }
            staying = false;
        }
    }
}