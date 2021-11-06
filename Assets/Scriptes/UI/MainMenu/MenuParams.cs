using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scriptes.UI.MainMenu {
    [CreateAssetMenu(fileName = "MenuParams", menuName = "MenuParams", order = 0)]
    public class MenuParams : ScriptableObject {
        public List<Sprite> Backgrounds;
        public float Speed;
    }
}