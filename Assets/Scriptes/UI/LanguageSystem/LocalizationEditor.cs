#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Assets.Scriptes.UI.LanguageSystem {
    [CustomEditor(typeof(TextSubstitutor))]
	public class LocalizationEditor : Editor {

		public override void OnInspectorGUI() {
			DrawDefaultInspector();
			TextSubstitutor lcz = (TextSubstitutor)target;
			if (GUILayout.Button("Build Default Locale")) {
				lcz.BuildDefaultLocale();
			}
		}
	}
}
#endif