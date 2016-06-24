using UnityEngine;

public class Crate : Entity {
    private ScoreUpdater score;
    private CargoUpdater cargo;

    protected override void Start() {
        base.Start();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreUpdater>();
        cargo = GameObject.FindGameObjectWithTag("Cargo").GetComponent<CargoUpdater>();
    }

    protected override void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            base.OnTriggerEnter2D(col);
            cargo.AddCrate();
            score.AddScore((int)ScoreUpdater.Points.Crate);
            DestroyEntity();
        }
    }
}
