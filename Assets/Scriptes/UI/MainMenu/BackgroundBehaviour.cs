using UnityEngine;

namespace Assets.Scriptes.UI.MainMenu {
    public class BackgroundBehaviour : MonoBehaviour {

        [SerializeField] GameObject plane1;
        [SerializeField] GameObject plane2;
        public float speed;
        public bool moving;

        [SerializeField] private Transform top;
        [SerializeField] private Transform bottom;
        void Update() {
            if (moving) {
                Moving(plane1);
                Moving(plane2);
            }
        }

        private void Moving(GameObject plane) {
            if (plane.transform.position.y >= top.position.y) {
                plane.transform.position = plane.transform.position + Vector3.down * 20;
            }
            plane.transform.position = Vector3.MoveTowards(
                    plane.transform.position,
                    plane.transform.position + Vector3.up,
                    speed * Time.deltaTime
                );
        }
    }
}