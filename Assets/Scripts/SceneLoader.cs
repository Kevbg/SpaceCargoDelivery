using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour {
    public static bool isLoading { get; private set; }
    public float fadeDuration = 1.5f;

    public void Load(string level) {
        isLoading = true;
        StartCoroutine(LoadScene(level));
    }

    public IEnumerator LoadScene(string level) {
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
        GameObject bgm = GameObject.FindGameObjectWithTag("BGM");
        float startTime = Time.realtimeSinceStartup;

        if (bgm != null) {
            bgm.GetComponent<BGMControl>().FadeOut(fadeDuration);
        }

        sf.FadeOut(fadeDuration);

        while (Time.realtimeSinceStartup < startTime + fadeDuration) {
            yield return null;
        }

        SceneManager.LoadScene(level, LoadSceneMode.Single);
        sf.FadeIn(fadeDuration);
        isLoading = false;

        if (Time.timeScale != 1) { Time.timeScale = 1; }
    }
}
