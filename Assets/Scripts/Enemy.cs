using UnityEngine;

public class Enemy : Entity {
    protected override void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            //TODO: Decrement player's lives and reset player pos or trigger death state
            DestroyEntity();
        }
    }
}
