using UnityEngine;

namespace Assets.Scriptes.Plate {
    public class PlateMouseControl : MonoBehaviour {
        [SerializeField] private PlateParams plateParams;

        private void OnMouseDrag() {
            var nextPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            nextPosition.z = transform.position.z;
            transform.position = Vector3.MoveTowards(
                    transform.position,
                    nextPosition,
                    plateParams.speed * 5 * Time.deltaTime
                );
            
        }
    }
}