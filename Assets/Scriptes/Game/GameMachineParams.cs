using UnityEngine;

namespace Assets.Scriptes.Game {
    [CreateAssetMenu(fileName = "GameMachineParams", menuName = "SandwichGame/GameMachineParams", order = 0)]
    public class GameMachineParams : ScriptableObject {
        public float spawnInterval;
        public float spawnIntervalScatter;

        public float sandwichSpawnChance;
        public float garbageSpawnChance;
        public float busterSpawnChance;

        public int loseLimit;
    }
}