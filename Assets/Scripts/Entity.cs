using UnityEngine;

public abstract class Entity : MonoBehaviour {
    public AudioClip collisionSFX;
    protected AudioSource sfx;
    protected Rigidbody2D body;
    protected float speed = 5;
    public float speedMultiplier = 1;

	protected virtual void Start () {
        body = GetComponent<Rigidbody2D>();
        Move();
	}

    protected virtual void Move() {
        body.velocity = new Vector2(0, -speed * speedMultiplier);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col) {
        if (collisionSFX != null) {
            sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
            sfx.PlayOneShot(collisionSFX);
        }
    }

    protected virtual void DestroyEntity() {
        Destroy(gameObject);
    }

    public virtual void MultiplySpeed(float value) {
        speedMultiplier = value;
    }

    public float GetSpeedMultiplier() {
        return speedMultiplier;
    }
}
