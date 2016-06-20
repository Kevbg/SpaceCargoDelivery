using UnityEngine;

public class Station : Entity {
    protected override void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            //TODO: Reset crate counter, add score
        }
    }
}
