using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public const int DefaultOrientationAngle = 45;
    public float xAxis { get; private set; }
    public float yAxis { get; private set; }
    public float xAccel { get; private set; }
    public float yAccel { get; private set; }
    public float speed;
    private Quaternion accelAdjustment;
    private Vector3 adjustedAccel;
    private Rigidbody2D body;
    private bool isMoving;

	void Start () {
        body = GetComponent<Rigidbody2D>();
        accelAdjustment = Quaternion.Euler(DefaultOrientationAngle, 0f, 0f);

        if (!Application.isEditor) {
            speed *= 4;
        }
    }

	void Update () {
        if (Application.isEditor) {
            xAxis = Input.GetAxisRaw("Horizontal");
            yAxis = Input.GetAxisRaw("Vertical");
        } else {
            adjustedAccel = accelAdjustment * Input.acceleration;
            xAccel = adjustedAccel.x;
            yAccel = adjustedAccel.y;
        }

        if (xAxis != 0 | yAxis != 0) {
            isMoving = true;
        } else if (xAccel != 0 | yAccel != 0) {
            xAccel = LimitRange(xAccel, -0.25f, 0.25f);
            yAccel = LimitRange(yAccel, -0.25f, 0.25f);
            isMoving = true;
        } else {
            isMoving = false;
        }
    }

    void FixedUpdate() {
        if (isMoving && Application.isEditor) {
            body.velocity = new Vector2(xAxis * speed, yAxis * speed);
        } else if (isMoving && !Application.isEditor) {
            body.velocity = new Vector2(xAccel * speed, yAccel * speed);
        }
    }

    void OnGUI() {
        string velX = GetComponent<Rigidbody2D>().velocity.x.ToString();
        string velY = GetComponent<Rigidbody2D>().velocity.y.ToString();
        GUI.Label(new Rect(10, 10, 100, 20), "X: " + velX);
        GUI.Label(new Rect(10, 30, 100, 20), "Y: " + velY);
    }

    float LimitRange(float value, float min, float max) {
        if (value <= min) {
            return min;
        } else if (value >= max) {
            return max;
        }
        return value;
    }
}
