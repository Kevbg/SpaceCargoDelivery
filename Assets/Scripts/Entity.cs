using UnityEngine;

public abstract class Entity : MonoBehaviour {
    public const float Speed = 5;
    public float speedMultiplier = 1;
    private Rigidbody2D body;

	protected virtual void Start () {
        body = GetComponent<Rigidbody2D>();
        Move();
	}

    protected virtual void Move() {
        body.velocity = new Vector2(0, -Speed * speedMultiplier);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col) {

    }

    protected virtual void DestroyEntity() {
        Destroy(gameObject);
    }
}
