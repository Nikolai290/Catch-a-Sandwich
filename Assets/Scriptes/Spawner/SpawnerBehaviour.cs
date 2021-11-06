using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scriptes.Spawner {
    public class SpawnerBehaviour : MonoBehaviour {

        [SerializeField] public SpawnerParams spawnerParams;

        public GameObject SpawnSandwich() {
            return Instantiate(GetRandomGameObject(spawnerParams.sanwichPrefabs), GetRandomPosition(), GetRandomQuaternion());
        }

        public GameObject SpawnGarbage() {
            return Instantiate(GetRandomGameObject(spawnerParams.garbagePrefabs), GetRandomPosition(), GetRandomQuaternion());
        }

        public GameObject SpawnBuster() {
            return Instantiate(GetRandomGameObject(spawnerParams.busterPrefabs), GetRandomPosition(), GetRandomQuaternion());
        }

        private GameObject GetRandomGameObject(List<GameObject> listObjects) {
            var length = listObjects.Count;
            var index = Random.Range(0, length);
            return listObjects[index];
        }

        private Quaternion GetRandomQuaternion() {
            return Quaternion.Euler(
                0f,
                Random.Range(0, 360),
                0f
            );
        }

        private Vector3 GetRandomPosition() {
            return new Vector3(
                transform.position.x + Random.Range(-spawnerParams.spawnDiapazon.x, spawnerParams.spawnDiapazon.x),
                transform.position.y + Random.Range(-spawnerParams.spawnDiapazon.y, spawnerParams.spawnDiapazon.y),
                transform.position.z + Random.Range(-spawnerParams.spawnDiapazon.z, spawnerParams.spawnDiapazon.z)
            );
        }
    }
}