using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scriptes.Plate {
    public class PlateTouchControl : MonoBehaviour, IDragHandler, IPointerDownHandler {

        [SerializeField] private PlateParams plateParams;
        [SerializeField] private Transform target;

        private Vector3 offset;

        public void DragPlate(Vector2 screenPosition) {
            var nextPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            nextPosition += offset;
            nextPosition.z = target.position.z;
            nextPosition = CheckBorders(nextPosition);
            target.position = Vector3.MoveTowards(
                    target.position,
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

            return new Vector3(x, y, position.z);
        }

        public void OnDrag(PointerEventData eventData) {
            DragPlate(eventData.position);
        }

        public void OnPointerDown(PointerEventData eventData) {
            offset = target.position - Camera.main.ScreenToWorldPoint(eventData.position);
        }
    }
}