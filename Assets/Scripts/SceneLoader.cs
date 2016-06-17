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
        sf.FadeOut(fadeDuration);
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(level, LoadSceneMode.Single);
        sf.FadeIn(fadeDuration);
        isLoading = false;
    }
}
