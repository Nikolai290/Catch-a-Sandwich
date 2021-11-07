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
            nextPostion = CheckBorders(nextPostion);
            transform.position = Vector3.MoveTowards(transform.position, nextPostion, speed * Time.deltaTime);
        }

        private Vector3 CheckBorders(Vector3 position) {
            var x = position.x > plateParams.MaxBorder.x
                ? plateParams.MaxBorder.x
                : position.x < plateParams.MinBorder.x
                ? plateParams.MinBorder.x
                : position.x;
            var y = position.y > plateParams.MaxBorder.y
                ? plateParams.MaxBorder.y
                : position.y < plateParams.MinBorder.y
                ? plateParams.MinBorder.y
                : position.y;

            return new Vector3(x, y, position.z);
        }
    }
}