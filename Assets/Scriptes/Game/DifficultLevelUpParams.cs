using UnityEngine;

namespace Assets.Scriptes.Game {
    [CreateAssetMenu(fileName = "DifficultLevelUpParams", menuName = "SandwichGame/DifficultLevelUpParams", order = 0)]
    public class DifficultLevelUpParams : ScriptableObject {
        [Header("Шаг изменения уровней сложности")]
        public int SpawnDifficultInterval;
        public int GarbageDifficultInterval;
        public int SandwichDifficultInterval;

        [Header("Изменение времени спавна")]
        [Tooltip(
            "Модификатор умножается на уровень сложности и прибавляется к базовому значению, " +
            "поэтому для уменьшения интервала указывай отрицательное число.")]
        public float SpawnTimeIntervalStep;
        [Tooltip(
            "Модификатор умножается на уровень сложности и прибавляется к базовому значению, " +
            "поэтому для уменьшения интервала указывай отрицательное число.")]
        public float SpawnScatterStep;
    }
}