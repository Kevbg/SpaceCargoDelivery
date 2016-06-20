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
        GetComponent<Image>().raycastTarget = true;
    }

    public void FadeIn(float duration, float minAlpha = 0) {
        img.CrossFadeAlpha(minAlpha, duration, true);
        GetComponent<Image>().raycastTarget = false;
    }

    public void QuickFadeOut() {
        img.CrossFadeAlpha(QuickFadeAlpha, QuickFadeDuration, true);
        GetComponent<Image>().raycastTarget = true;
    }

    public void QuickFadeIn() {
        img.CrossFadeAlpha(0, QuickFadeDuration, true);
        GetComponent<Image>().raycastTarget = false;
    }
}
