using Assets.Scriptes.Common;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scriptes.UI.FinishScreen {
    public class FinishScreenBahaviour : MonoBehaviour {

        [SerializeField] private Text finalScore;
        [SerializeField] private Text finalTime;
        [SerializeField] private Text joke;
        [SerializeField] private GameObject FinishScreen;
        [SerializeField] private Jokes jokes;

        public static Action OnFinishGame;

        public void Show(int score, float time) {
            OnFinishGame?.Invoke();
            FinishScreen.SetActive(true);
            finalScore.text = "Your scores: " + score;
            finalTime.text = "Your time: " + new MyTime(time).ToString();
            joke.text = jokes.jokes[Random.Range(0, jokes.jokes.Length)];
        }
    }
}