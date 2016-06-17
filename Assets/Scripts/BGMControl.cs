using UnityEngine;
using UnityEngine.UI;

public class BGMControl : MonoBehaviour {
    public Slider slider;
    private AudioSource source;

    void Awake() {
        source = GetComponent<AudioSource>();
    }

    void OnEnable() {
        slider.value = GameController.bgmVolume;
    }

    public void UpdateBGMVolume() {
        GameController.bgmVolume = slider.value;
        source.volume = slider.value;
    }
}
