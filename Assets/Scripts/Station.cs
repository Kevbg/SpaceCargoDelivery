using System;
using UnityEngine;

public class Station : Entity {
    public const float BonusMultiplier = 2f;
    public const float RotationAngle = 45;
    public Vector3 rotation { get; private set; }
    private ScoreUpdater score;
    private CargoUpdater cargo;

    protected override void Start() {
        base.Start();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreUpdater>();
        cargo = GameObject.FindGameObjectWithTag("Cargo").GetComponent<CargoUpdater>();
        rotation = new Vector3(0, 0, 360 - RotationAngle);
        transform.rotation = Quaternion.Euler(rotation);
    }

    protected override void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player" && cargo.count > 0) {
            base.OnTriggerEnter2D(col);
            score.AddScore(cargo.count * (int)ScoreUpdater.Points.Station + GetBonus());
            cargo.RemoveAllCargo();
        }
    }

    int GetBonus() {
        return (int)(Math.Pow(cargo.count, 2) * BonusMultiplier);
    }
}
