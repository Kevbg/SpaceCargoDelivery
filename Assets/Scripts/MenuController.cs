using UnityEngine;

public class MenuController : MonoBehaviour {
    public GameObject gameOverMenu;
    public GameObject gameOverText;
    public GameObject pausedText;

    public void Pause() {
        pausedText.SetActive(true);
        GameController.current.Pause();
    }

    public void Resume() {
        pausedText.SetActive(false);
        GameController.current.Resume();
    }

    public void EndGame() {
        gameOverText.SetActive(true);
        gameOverMenu.SetActive(true);
        GameController.current.Pause();
    }

    public void Exit(float fadeOutDuration) {
        StartCoroutine(GameController.current.ExitGame(fadeOutDuration));
    }
}
