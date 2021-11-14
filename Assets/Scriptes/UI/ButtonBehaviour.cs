using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scriptes.UI {
    public class ButtonBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

        public static Action onButtonDown;
        public static Action onButtonUp;

        public void OnPointerDown(PointerEventData eventData) {
            transform.localScale = new Vector3(0.9f, 0.9f, 1f);
            onButtonDown?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData) {
            transform.localScale = new Vector3(1f, 1f, 1f);
            onButtonUp?.Invoke();
        }
    }
}