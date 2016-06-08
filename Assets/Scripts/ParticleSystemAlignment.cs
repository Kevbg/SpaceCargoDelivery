using UnityEngine;
using System.Collections;

public class ParticleSystemAlignment : MonoBehaviour {
    private ParticleSystem particles;

	void Start () {
        particles = GetComponent<ParticleSystem>();
        ParticleSystem.ShapeModule shape = particles.shape;
        Vector3 topAlignment = new Vector3(
            (Camera.main.orthographicSize * 2) * GameController.current.aspectRatio, 
            shape.box.y,
            shape.box.z
        );

        transform.position = new Vector3(
            transform.position.x, 
            Camera.main.orthographicSize + shape.box.y / 2,
            transform.position.z
        );

        shape.box = topAlignment;
    }
}
