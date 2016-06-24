using UnityEngine;

public class ObjectManager : MonoBehaviour {
    public const float MinEnemySpawnTime = 0.33f;
    public const float MaxEnemySpawnTime = 1f;
    public const float MinCrateSpawnTime = 0.75f;
    public const float MaxCrateSpawnTime = 4f;
    public const float MinStationSpawnTime = 10f;
    public const float MaxStationSpawnTime = 25f;
    public const float MinEnemySpeedMult = 1.5f;
    public const float MaxEnemySpeedMult = 4f;
    public GameObject enemy;
    public GameObject crate;
    public GameObject station;

	void Start () {
        Invoke("SpawnEnemies", 0);
        Invoke("SpawnCrates", MinCrateSpawnTime);
        Invoke("SpawnStations", MinStationSpawnTime);
	}

    void SpawnEnemies() {
        float spawnTimer = Random.Range(MinEnemySpawnTime, MaxEnemySpawnTime);
        float randomSpeed = Random.Range(MinEnemySpeedMult, MaxEnemySpeedMult);

        enemy.GetComponent<Enemy>().MultiplySpeed(randomSpeed);
        Instantiate(enemy, RandomSpawnPoint(enemy), Quaternion.identity);
        Invoke("SpawnEnemies", spawnTimer);
    }

    void SpawnCrates() {
        Instantiate(crate, RandomSpawnPoint(crate), Quaternion.identity);
        float spawnTimer = Random.Range(MinCrateSpawnTime, MaxCrateSpawnTime);
        Invoke("SpawnCrates", spawnTimer);
    }

    void SpawnStations() {
        Instantiate(station, RandomSpawnPoint(station), Quaternion.identity);
        float spawnTimer = Random.Range(MinStationSpawnTime, MaxStationSpawnTime);
        Invoke("SpawnStations", spawnTimer);
    }

    Vector3 RandomSpawnPoint(GameObject go) {
        float width = go.GetComponent<SpriteRenderer>().bounds.size.x;
        float randomX = Random.Range(
            -GameController.current.screenWidth / 2 + width / 2,
             GameController.current.screenWidth / 2 - width / 2
        );
        return new Vector3(transform.position.x + randomX, transform.position.y);
    }
}
