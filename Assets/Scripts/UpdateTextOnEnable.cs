using UnityEngine;

public class UpdateTextOnEnable : MonoBehaviour {
    private LanguageSwitcher ls;

    void Awake() {
        ls = GetComponentInParent<LanguageSwitcher>();
    }

	void OnEnable() {
        ls.SetMenuText();
    }
}
