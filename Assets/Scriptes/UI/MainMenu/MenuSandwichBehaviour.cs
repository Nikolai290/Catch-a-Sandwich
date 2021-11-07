using Assets.Scriptes.FallObject;
using System.Collections;
using UnityEngine;

namespace Assets.Scriptes.UI.MainMenu {
    public class MenuSandwichBehaviour : MonoBehaviour {

        [SerializeField] protected MenuSandwichParams param;

        private Vector3 torque;
        private void OnEnable() {
            torque = param.Torque;
            if (param.randomTorque) {
                torque = new Vector3(
                        param.xRotate ? GetRandomFloat() : 0,
                        param.yRotate ? GetRandomFloat() : 0,
                        param.zRotate ? GetRandomFloat() : 0
                    );
            }
        }

        private void Update() {
            transform.Rotate(torque * Time.deltaTime);
        }

        private float GetRandomFloat() {
            var torque = Random.Range(param.minTorque, param.maxTorque);
            return Random.Range(0f, 1f) > 0.5f ? torque : -torque;
        }
    }
}