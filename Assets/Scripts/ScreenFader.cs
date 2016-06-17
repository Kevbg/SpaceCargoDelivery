using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour {
    public const float QuickFadeAlpha = 100f;
    public const float QuickFadeDuration = 0.2f;
    private static ScreenFader current;
    private Image img;

    void Awake() {
        if (current == null) {
            DontDestroyOnLoad(gameObject);
            current = this;
            img = GetComponent<Image>();
        } else if (current != this) {
            Destroy(gameObject);
        }
    }

    void OnLevelWasLoaded() {
        GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void FadeOut(float duration, float maxAlpha = 255) {
        img.CrossFadeAlpha(maxAlpha, duration, true);
        StartCoroutine(DisableMouseClicks(duration));
    }

    public void FadeIn(float duration, float minAlpha = 0) {
        img.CrossFadeAlpha(minAlpha, duration, true);
    }

    public void QuickFadeOut() {
        img.CrossFadeAlpha(QuickFadeAlpha, QuickFadeDuration, true);
        StartCoroutine(DisableMouseClicks(QuickFadeDuration));
    }

    public void QuickFadeIn() {
        img.CrossFadeAlpha(0, QuickFadeDuration, true);
    }

    public IEnumerator DisableMouseClicks(float duration) {
        GetComponent<Image>().raycastTarget = true;
        yield return new WaitForSeconds(duration);
        GetComponent<Image>().raycastTarget = false;
    }
}
