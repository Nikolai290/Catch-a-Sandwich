using System.Linq;
using UnityEngine;

namespace Assets.Scriptes.Common {
    public class MyTime {
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int milliseconds { get; set; }
        public float totalSeconds { get; set; }
        public int totalSecondsInt { get; set; }

        public MyTime(float seconds) {
            this.totalSeconds = seconds;
            this.totalSecondsInt = Mathf.FloorToInt(totalSeconds);
            this.milliseconds = (int)(seconds - totalSecondsInt);
            this.minutes = totalSecondsInt / 60;
            this.seconds = totalSecondsInt % 60;
        }

        public MyTime Set(float seconds) {
            this.totalSeconds = seconds;
            this.totalSecondsInt = Mathf.FloorToInt(totalSeconds);
            this.milliseconds = (int)((seconds - totalSecondsInt)*100);
            this.minutes = totalSecondsInt / 60;
            this.seconds = totalSecondsInt % 60;
            return this;
        }

        public override string ToString() {
            return $"{minutes.ToString()}:{seconds}:{milliseconds}";
        }
    }
}