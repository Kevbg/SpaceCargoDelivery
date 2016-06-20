using UnityEngine;

public class MenuController : MonoBehaviour {
    public void Pause() {
        GameController.current.Pause();
    }

    public void Resume() {
        GameController.current.Resume();
    }

    public void Exit(float fadeOutDuration) {
        StartCoroutine(GameController.current.ExitGame(fadeOutDuration));
    }
}
