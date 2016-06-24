using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {
    public Text finalScore;
    private Text score;
    public int currentScore { get; private set; }
    public enum Points {
        Crate = 10,
        Station = 50
    }

	void Start () {
        score = GetComponent<Text>();
        currentScore = int.Parse(score.text);
        UpdateScore();
	}

    public void UpdateScore() {
        if (currentScore < 0) { currentScore = 0; }
        score.text = currentScore.ToString();
        finalScore.text = score.text;
    }
	
	public void AddScore(int amount) {
        currentScore += amount;
        UpdateScore();
    }
}
