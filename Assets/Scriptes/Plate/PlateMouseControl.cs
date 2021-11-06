using UnityEngine;

namespace Assets.Scriptes.Plate {
    public class PlateMouseControl : MonoBehaviour {
        [SerializeField] private PlateParams plateParams;

        private void OnMouseDrag() {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var offset = transform.position - mousePosition;
            var nextPosition = mousePosition - offset;
            nextPosition.z = transform.position.z;
            transform.position = Vector3.MoveTowards(
                    transform.position,
                    nextPosition,
                    plateParams.speed * 3 * Time.deltaTime
                );
            
        }
    }
}