using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitcher : MonoBehaviour {
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
        JsonParser parser = GameObject.FindGameObjectWithTag("Menu").GetComponent<JsonParser>();
        return parser.GetItem(item, GameController.language.ToString()).ToString();
    }
}
