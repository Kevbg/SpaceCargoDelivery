using UnityEngine;
using System.IO;
using LitJson;

public class JsonParser : MonoBehaviour {
    private string strings;
    private string stringsFilePath;
    private JsonData data;

    void Awake() {
        stringsFilePath = Application.dataPath + "/StreamingAssets/Json/Strings.json";
        Parse(stringsFilePath);
    }

    void Parse(string filePath) {
        strings = File.ReadAllText(stringsFilePath);
        data = JsonMapper.ToObject(strings);
    }

    public JsonData GetItem(string item, string language) {
        return data[item][language];
    }
}
