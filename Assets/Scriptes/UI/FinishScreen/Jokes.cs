﻿using UnityEngine;

namespace Assets.Scriptes.UI.FinishScreen {
    [CreateAssetMenu(fileName = "Jokes", menuName = "Jokes", order = 0)]
    public class Jokes : ScriptableObject {
        public string[] jokes;
    }
}