using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public static GameController current;
    public float aspectRatio { get; private set; }
    public static Languages language { get; set; }

    public enum Languages {
        english,
        portuguese
    }

    void Awake() {
        if (current == null) {
            DontDestroyOnLoad(gameObject);
            current = this;

            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            aspectRatio = (float)Screen.width / (float)Screen.height;
        } else if (current != this) {
            Destroy(gameObject);
        }
    }
}
