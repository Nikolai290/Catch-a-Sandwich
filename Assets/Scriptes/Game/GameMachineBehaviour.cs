using Assets.Scriptes.Sandwich;
using Assets.Scriptes.Spawner;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scriptes.Game {
    public class GameMachineBehaviour : MonoBehaviour {
        [SerializeField] private SpawnerBehaviour spawnerBehaviour;
        [SerializeField] private Text ScoreText;
        [SerializeField] private Text LoserText;
        [SerializeField] private GameObject InGameHud;
        [SerializeField] private GameObject PauseMenu;
        [SerializeField] private Transform PlateControl;
        [SerializeField] private Transform PlateDefaultPostion;

        [SerializeField] private GameMachineParams gameMachineParams;

        public int maxLoses;
        private int Loses;
        public int Scores { get; private set; }


        public bool playGame { get; private set; }
        private bool coroutineStarted = false;

        private float sumChance;

        private List<GameObject> spawnedObjects = new List<GameObject>();

        private void Start() {
            SandwichBehaviour.OnScoreUp += ScoreUpHandler;
            SandwichBehaviour.OnLosing += LosingHandler;
        }

        public void NewGame() {
            PlateControl.position = PlateDefaultPostion.position;
            InGameHud.SetActive(true);
            Loses = 0;
            Scores = 0;
            LoserText.text = $"Loses: {Loses}";
            LoserText.text = $"Scores: {Loses}";
            Play();
        }

        private void Play() {
            playGame = true;
            if (coroutineStarted) return;
            coroutineStarted = true;
            StartCoroutine(GameCycle());
        }

        public void StopGame() {
            playGame = false;
            CleanSpawnedObjectList();
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

        private void CleanSpawnedObjectList() {
            spawnedObjects.ForEach(x => { 
                if(x != null) {
                    Destroy(x);
                }
            });
            spawnedObjects = new List<GameObject>();
        }

        private void SpawnObject(float chance) {
            var sandwichGarbage = gameMachineParams.sandwichSpawnChance + gameMachineParams.garbageSpawnChance;
            if (chance < gameMachineParams.sandwichSpawnChance) {
                var spawnedObject = spawnerBehaviour.SpawnSandwich();
                spawnedObjects.Add(spawnedObject);
                return;
            }
            if (chance >= gameMachineParams.sandwichSpawnChance
             && chance < sandwichGarbage) {
                var spawnedObject = spawnerBehaviour.SpawnGarbage();
                spawnedObjects.Add(spawnedObject);
                return;
            }
            if (chance >= sandwichGarbage
             && chance < sumChance) {
                var spawnedObject = spawnerBehaviour.SpawnBuster();
                spawnedObjects.Add(spawnedObject);
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