using UnityEngine;

public class Despawner : MonoBehaviour {

	void Start () {
        transform.localScale = new Vector3(GameController.current.screenWidth, transform.localScale.y);
	}

    void OnTriggerEnter2D(Collider2D col) {
        Destroy(col.gameObject);
    }
}
