using UnityEngine;
using UnityEngine.UI;

public class SFXControl : MonoBehaviour {
    public Slider slider;
    private AudioSource source;

	void Awake() {
        source = GetComponent<AudioSource>();
	}

    void OnEnable() {
        slider.value = GameController.sfxVolume;
    }

    public void UpdateSFXVolume() {
        GameController.sfxVolume = slider.value;
        source.volume = slider.value;
    }
}
