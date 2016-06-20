using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//#if UNITY_EDITOR
//using UnityEditor;
//#endif

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

    public void FadeOut(float speed = 1.5f) {
        StartCoroutine(VolumeFadeOut(speed));
    }

    IEnumerator VolumeFadeOut(float speed) {
        float threshold = 0.01f;
        while (source.volume > threshold) {
            source.volume = Mathf.Lerp(source.volume, 0, Time.deltaTime * speed);
            yield return null;
        }
        source.volume = 0;
    }
}

//#if UNITY_EDITOR
//[CustomEditor(typeof(BGMControl))]
//public class BGMControlEditor: Editor {
//    public override void OnInspectorGUI() {
//        base.OnInspectorGUI();
//        BGMControl control = (BGMControl)target;

//        if (GUILayout.Button("Fade Out")) {
//            control.FadeOut();
//        }
//    }
//}
//#endif
