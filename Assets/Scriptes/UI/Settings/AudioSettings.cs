using Assets.Scriptes.Sounds;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scriptes.Common.PlayerPrefsKeys;

namespace Assets.Scriptes.UI.Settings {
    public class AudioSettings : MonoBehaviour {

        private float defaultMusicVolume = 0.3f;
        private float defaultEffectsVolume = 0.6f;

        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider effectsSlider;

        [SerializeField] private GameObject audioSettingsPanel;

        [SerializeField] private AudioActionListener audioActionListener;

        // mute
        [SerializeField] private Sprite SoundsOn;
        [SerializeField] private Sprite SoundsOff;
        [SerializeField] private GameObject muteButton;
        private bool mute;
        //


        private float musicVolume;
        private float effectsVolume;

        private void Awake() {
        }
        private void Start() {
            DownloadSettings();
            audioSettingsPanel.SetActive(false);
        }

        private void DownloadSettings() {
            musicVolume = defaultMusicVolume;
            effectsVolume = defaultEffectsVolume;
            if (PlayerPrefs.HasKey(MUSIC_VOLUME)) {
                musicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME);
            }
            if (PlayerPrefs.HasKey(EFFECTS_VOLUME)) {
                effectsVolume = PlayerPrefs.GetFloat(EFFECTS_VOLUME);
            }
            if (PlayerPrefs.HasKey(SOUNDS_MUTE)) {
                mute = PlayerPrefs.GetInt(SOUNDS_MUTE) != 0;
            }
            musicSlider.value = musicVolume;
            effectsSlider.value = effectsVolume;

            SetSoundsMute(mute);
        }

        public void OnMusicVolumeChangedHandler() {
            musicVolume = musicSlider.value;
            audioActionListener.SetMusicVolume(musicVolume);
        }

        public void OnEffectsVolumeChangedHandler() {
            effectsVolume = effectsSlider.value;
            audioActionListener.SetEffectsVolume(effectsVolume);
        }

        public void OnSaveAuidoSettings() {
            PlayerPrefs.SetFloat(MUSIC_VOLUME, musicVolume);
            PlayerPrefs.SetFloat(EFFECTS_VOLUME, effectsVolume);
        }

        public void OnMuteSoundsButtonHandler() {
            mute = !mute;
            SetSoundsMute(mute);
        }

        private void SetSoundsMute(bool isMute) {
            PlayerPrefs.SetInt(SOUNDS_MUTE, isMute ? 1 : 0);
            audioActionListener.Mute(isMute);
            muteButton.GetComponent<Image>().sprite = mute ? SoundsOff : SoundsOn;
        }
    }
}