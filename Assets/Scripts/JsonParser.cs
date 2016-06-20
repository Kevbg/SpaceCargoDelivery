using UnityEngine;
using LitJson;

public class JsonParser : MonoBehaviour {
    private JsonData data;

    void Awake() {
        TextAsset file = Resources.Load("Json/strings") as TextAsset;
        data = JsonMapper.ToObject(file.ToString());
    }

    public JsonData GetItem(string item, string language) {
        return data[item][language];
    }
}
