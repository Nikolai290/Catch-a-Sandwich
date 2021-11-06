using Assets.Scriptes.FallObject;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scriptes.Spawner {
    [CreateAssetMenu(fileName = "SpawnerParams01", menuName = "SpawnerParams", order = 0)]
    public class SpawnerParams : ScriptableObject {
        public Vector3 spawnDiapazon;

        public List<GameObject> sanwichPrefabs;
        public List<GameObject> garbagePrefabs;
        public List<GameObject> busterPrefabs;
    }
}