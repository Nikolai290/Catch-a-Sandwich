using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scriptes.Plate {
    public class PlateKeyBoardControl : MonoBehaviour {

        [SerializeField] private PlateParams plateParams;


        private float hor;
        private float ver;

        private float speed;

        public Action<int> onScoreChanged;

        private void Start() {
            speed = plateParams.speed;
        }

        void Update() {
            hor = Input.GetAxis("Horizontal");
            ver = Input.GetAxis("Vertical");

            var nextPostion = new Vector3(
                    transform.position.x + hor,
                    transform.position.y + ver,
                    transform.position.z
                );
            transform.position = Vector3.MoveTowards(transform.position, nextPostion, speed * Time.deltaTime);
        }
    }
}