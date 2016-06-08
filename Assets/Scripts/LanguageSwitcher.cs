using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitcher : MonoBehaviour {
    void Start() {
        switch (GameController.language) {
            case GameController.Languages.portuguese:
                Portuguese();
                break;
        }
    }

    public void English() {
        GameController.language = GameController.Languages.english;
    }

    public void Portuguese() {
        GameController.language = GameController.Languages.portuguese;
    }

    public void SetMenuText() {
        Component[] texts = GetComponentsInChildren<Text>();

        foreach (Text txt in texts) {
                txt.text = FetchItem(txt.name);
        }
    }

    public string FetchItem(string item) {
        JsonParser parser = GameObject.FindGameObjectWithTag("GameController").GetComponent<JsonParser>();
        return parser.GetItem(item, GameController.language.ToString()).ToString();
    }
}
