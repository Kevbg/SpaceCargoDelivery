using UnityEngine;
using System.Collections;

public class ColliderAlignment : MonoBehaviour {
    public Alignment alignment;

    public enum Alignment {
        Top,
        Left,
        Bottom,
        Right
    }

	void Start () {
        float width = GetComponent<BoxCollider2D>().bounds.size.x;
        float height = GetComponent<BoxCollider2D>().bounds.size.y;

        switch (alignment) {
            case Alignment.Top:
                transform.localScale = new Vector3(
                    (Camera.main.orthographicSize * 2) * GameController.current.aspectRatio, 
                    transform.localScale.y
                );
                transform.position = new Vector3(
                    transform.position.x, 
                    Camera.main.orthographicSize + height / 2
                );
                break;
            case Alignment.Left:
                transform.localScale = new Vector3(transform.localScale.x, Camera.main.orthographicSize * 2);
                transform.position = new Vector3(
                    -Camera.main.orthographicSize * GameController.current.aspectRatio - width / 2, 
                    transform.position.y
                );
                break;
            case Alignment.Bottom:
                transform.localScale = new Vector3(
                    (Camera.main.orthographicSize * 2) * GameController.current.aspectRatio, 
                    transform.localScale.y
                );
                transform.position = new Vector3(
                    transform.position.x, 
                    (-Camera.main.orthographicSize - height / 2)
                );
                break;
            case Alignment.Right:
                transform.localScale = new Vector3(transform.localScale.x, Camera.main.orthographicSize * 2);
                transform.position = new Vector3(
                    Camera.main.orthographicSize * GameController.current.aspectRatio + width / 2, 
                    transform.position.y
                );
                break;
        }
	}
}
