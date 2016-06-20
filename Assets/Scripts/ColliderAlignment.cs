using UnityEngine;

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
                    GameController.current.screenWidth, 
                    transform.localScale.y
                );
                transform.position = new Vector3(
                    transform.position.x, 
                    GameController.current.screenHeight / 2 + height / 2
                );
                break;
            case Alignment.Left:
                transform.localScale = new Vector3(transform.localScale.x, GameController.current.screenHeight);
                transform.position = new Vector3(
                    -GameController.current.screenWidth / 2 - width / 2, 
                    transform.position.y
                );
                break;
            case Alignment.Bottom:
                transform.localScale = new Vector3(
                    GameController.current.screenWidth, 
                    transform.localScale.y
                );
                transform.position = new Vector3(
                    transform.position.x, 
                    -GameController.current.screenHeight / 2 - height / 2
                );
                break;
            case Alignment.Right:
                transform.localScale = new Vector3(transform.localScale.x, GameController.current.screenHeight);
                transform.position = new Vector3(
                    GameController.current.screenWidth / 2 + width / 2, 
                    transform.position.y
                );
                break;
        }
	}
}
