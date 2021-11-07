using Assets.Scriptes.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scriptes.UI.FinishScreen {
    public class FinishScreenBahaviour : MonoBehaviour {

        [SerializeField] private Text finalScore;
        [SerializeField] private Text finalTime;
        [SerializeField] private GameObject FinishScreen;


        public void Show(int score, float time) {
            FinishScreen.SetActive(true);
            finalScore.text = "Your scores: " + score;
            finalTime.text = "Your time: " + new MyTime(time).ToString();
        }
    }
}