using UnityEngine;

namespace Assets.Scriptes.Player {
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "SandwichGame/PlayerStats", order = 0)]
    public class PlayerStats : ScriptableObject {
        public string FirebaseId { get; private set; }
        public string Name { get; private set; }
        public int HighScore { get; private set; }
        public int HighTime { get; private set; }

        public int AllScores { get; private set; }
    }
}