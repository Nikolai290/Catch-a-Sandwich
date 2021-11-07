using UnityEngine;

namespace Assets.Scriptes.Plate {
    public class PlateMouseControl : MonoBehaviour {
        [SerializeField] private PlateParams plateParams;

        private void OnMouseDrag() {
            var nextPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            nextPosition.z = transform.position.z;
            nextPosition = CheckBorders(nextPosition);
            transform.position = Vector3.MoveTowards(
                    transform.position,
                    nextPosition,
                    plateParams.speed * 5 * Time.deltaTime
                );
            
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

            return new Vector3(x,y,position.z);
        }
    }
}