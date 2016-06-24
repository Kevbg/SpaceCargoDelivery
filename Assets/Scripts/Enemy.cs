using UnityEngine;

public class Enemy : Entity {
    protected const float MinSpeedFlip = 2f;
    private Player player;

    protected override void Start() {
        base.Start();

        if (speedMultiplier <= MinSpeedFlip) {
            FlipVertically();
        }
    }

    protected override void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            if (!player.isInvulnerable) {
                base.OnTriggerEnter2D(col);
                player.Kill();
                DestroyEntity();
            }
        }
    }

    public void FlipVertically() {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        switch(sprite.flipY){
            case true:
                sprite.flipY = false;
                break;
            case false:
                sprite.flipY = true;
                break;
        }
    }
}
