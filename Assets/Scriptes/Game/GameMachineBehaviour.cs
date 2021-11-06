using Assets.Scriptes.Sandwich;
using Assets.Scriptes.Spawner;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scriptes.Game {
    public class GameMachineBehaviour : MonoBehaviour {
        [SerializeField] private SpawnerBehaviour spawnerBehaviour;
        [SerializeField] private Text ScoreText;
        [SerializeField] private Text LoserText;

        [SerializeField] private GameMachineParams gameMachineParams;

        public int maxLoses;
        private int Loses;
        public int Scores { get; private set; }

        private bool playGame = false;

        private float sumChance;

        private void Start() {

            LoserText.text = $"Loses: {Loses}";

            SandwichBehaviour.OnScoreUp += ScoreUpHandler;
            SandwichBehaviour.OnLosing += LosingHandler;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space) && !playGame) {
                // start game
                playGame = true;
                StartCoroutine(GameCycle());
            }
        }

        private IEnumerator GameCycle() {
            while (playGame) {
                sumChance = gameMachineParams.sandwichSpawnChance
                          + gameMachineParams.garbageSpawnChance
                          + gameMachineParams.busterSpawnChance;
                var chance = Random.Range(0, sumChance);
                SpawnObject(chance);
                var scatter = gameMachineParams.spawnIntervalScatter;
                var interval = gameMachineParams.spawnInterval + Random.Range(-scatter, scatter);
                yield return new WaitForSeconds(interval);
            }
        }

        private void SpawnObject(float chance) {
            var sandwichGarbage = gameMachineParams.sandwichSpawnChance + gameMachineParams.garbageSpawnChance;
            if (chance < gameMachineParams.sandwichSpawnChance) {
                var spawnedObject = spawnerBehaviour.SpawnSandwich();
                return;
            }
            if (chance >= gameMachineParams.sandwichSpawnChance
             && chance < sandwichGarbage) {
                var spawnedObject = spawnerBehaviour.SpawnGarbage();
                return;
            }
            if (chance >= sandwichGarbage
             && chance < sumChance) {
                var spawnedObject = spawnerBehaviour.SpawnBuster();
                return;
            }
        }

        private void LosingHandler() {
            Loses += 1;
            LoserText.text = $"Loses: {Loses}";
            if(Loses >= maxLoses) {
                LoserText.text = $"You are LOSER!! ^_^ {Loses}";
            }
        }

        private void ScoreUpHandler() {
            Scores += 1;
            ScoreText.text = $"Scores: {Scores}";
        }
    }
}