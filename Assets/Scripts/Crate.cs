using UnityEngine;

public class Crate : Entity {

    protected override void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            // TODO: Increment crate counter, add score
            DestroyEntity();
        }
    }
}
