using UnityEngine;

public class ObjectManager : MonoBehaviour {
    public GameObject enemy;
    public GameObject crate;
    public GameObject station;

	void Start () {
        Invoke("SpawnEnemy", 0);
	}

    void SpawnEnemy() {
        float spawnTimer = Random.Range(0.25f, 1f);
        Instantiate(enemy, SpawnPoint(enemy), Quaternion.identity);
        enemy.GetComponent<Enemy>().speedMultiplier = Random.Range(0.5f, 2f);
        Invoke("SpawnEnemy", spawnTimer);
    }

    Vector3 SpawnPoint(GameObject go) {
        float width = go.GetComponent<SpriteRenderer>().bounds.size.x;
        float randomX = Random.Range(
            -GameController.current.screenWidth / 2 + width / 2,
             GameController.current.screenWidth / 2 - width / 2
        );
        return new Vector3(transform.position.x + randomX, transform.position.y);
    }
}
