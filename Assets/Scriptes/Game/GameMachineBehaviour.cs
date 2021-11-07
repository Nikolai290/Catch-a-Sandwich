using Assets.Scriptes.Common;
using Assets.Scriptes.Garbage;
using Assets.Scriptes.Sandwich;
using Assets.Scriptes.Spawner;
using Assets.Scriptes.UI.FinishScreen;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scriptes.Game {
    public class GameMachineBehaviour : MonoBehaviour {
        [SerializeField] private SpawnerBehaviour spawnerBehaviour;
        [SerializeField] private Text ScoreText;
        [SerializeField] private Text LoserText;
        [SerializeField] private Text TimerText;
        [SerializeField] private GameObject InGameHud;
        [SerializeField] private FinishScreenBahaviour FinishScreen;
        [SerializeField] private Transform PlateControl;
        [SerializeField] private Transform PlateDefaultPostion;

        [SerializeField] private GameMachineParams gameMachineParams;

        public int Loses { get; private set; }
        public int Scores { get; private set; }
        public MyTime TimeResult { get; private set; }

        
        public bool playGame { get; private set; }
        private bool coroutineStarted = false;

        private float sumChance;

        private float startTime;
        private float stopTime;
        private float totalTimeResult => stopTime - startTime;


        private List<GameObject> spawnedObjects = new List<GameObject>();

        private void Start() {
            SandwichBehaviour.OnScoreUp += ScoreUpHandler;
            SandwichBehaviour.OnLosing += LosingHandler;
            GarbageBehaviour.OnCollisionPlate += LosingHandler;
        }

        public void NewGame() {
            Time.timeScale = 1;
            PlateControl.gameObject.SetActive(true);
            PlateControl.position = PlateDefaultPostion.position;
            InGameHud.SetActive(true);

            Loses = 0;
            Scores = 0;
            startTime = Time.realtimeSinceStartup;

            LoserText.text = $"Loses: {Loses}";
            ScoreText.text = $"Scores: {Loses}";
            TimerText.text = "t: 00:00:00";

            Play();
        }

        private void Play() {
            playGame = true;
            TimeResult = new MyTime(0);
            if (coroutineStarted) return;
            coroutineStarted = true;
            StartCoroutine(Timer());
            StartCoroutine(GameCycle());
        }

        private IEnumerator Timer() {
            while (coroutineStarted) {
                yield return new WaitForSeconds(0.01f);
                if (!playGame) continue;
                stopTime = Time.realtimeSinceStartup;
                TimerText.text = "t: " + TimeResult.Set(totalTimeResult).ToString();
            }
        }

        public void StopGame() {
            PlateControl.gameObject.SetActive(false);
            playGame = false;
            stopTime = Time.realtimeSinceStartup;
            CleanSpawnedObjectList();
        }

        public void FinishGame() {
            StopGame();
            //Показать экран результатов и записать их
            InGameHud.SetActive(false);
            FinishScreen.Show(Scores, totalTimeResult);
        }

        private IEnumerator GameCycle() {
            while (coroutineStarted) {
                var scatter = gameMachineParams.spawnIntervalScatter;
                var interval = gameMachineParams.spawnInterval + Random.Range(-scatter, scatter);
                yield return new WaitForSeconds(interval);
                if (!playGame) continue;
                sumChance = gameMachineParams.sandwichSpawnChance
                          + gameMachineParams.garbageSpawnChance
                          + gameMachineParams.busterSpawnChance;
                var chance = Random.Range(0, sumChance);
                SpawnObject(chance);

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
            if(Loses >= gameMachineParams.loseLimit) {
                LoserText.text = $"You are LOSER!! ^_^ {Loses}";
                FinishGame();
            }
        }

        private void ScoreUpHandler() {
            Scores += 1;
            ScoreText.text = $"Scores: {Scores}";
        }
    }
}