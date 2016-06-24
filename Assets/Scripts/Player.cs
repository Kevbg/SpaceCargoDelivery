using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity {
    public const int MaxLives = 5;
    public const float DefaultSpeed = 7;
    public const float AndroidSpeedMult = 4;
    public const float InvulneravbilityDuration = 2;
    public Text lifeCounter;
    public float xAxis { get; private set; }
    public float yAxis { get; private set; }
    public float xAccel { get; private set; }
    public float yAccel { get; private set; }
    public int lives { get; private set; }
    public bool isInvulnerable { get; private set; }
    private bool isMoving;
    private Quaternion accelAdjustment;
    private Vector3 adjustedAccel;

	protected override void Start () {
        body = GetComponent<Rigidbody2D>();
        accelAdjustment = Quaternion.Euler(GameController.DefaultOrientationAngle, 0f, 0f);
        speed = DefaultSpeed;
        lives = MaxLives;
        UpdateLifeCounter();

        if (Application.platform == RuntimePlatform.Android) {
            speedMultiplier = AndroidSpeedMult;
        }
    }

	void Update () {
        if (Application.platform != RuntimePlatform.Android) {
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
            xAccel = LimitRange(xAccel, -1 / speedMultiplier, 1 / speedMultiplier);
            yAccel = LimitRange(yAccel, -1 / speedMultiplier, 1 / speedMultiplier);
            isMoving = true;
        } else {
            isMoving = false;
        }
    }

    void FixedUpdate() {
        if (isMoving) { Move(); }
    }

    protected override void Move() {
        if (Application.platform != RuntimePlatform.Android) {
            body.velocity = new Vector2(
                xAxis * (speed * speedMultiplier), 
                yAxis * (speed * speedMultiplier)
            );
        } else {
            body.velocity = new Vector2(
                xAccel * (speed * speedMultiplier), 
                yAccel * (speed * speedMultiplier)
            );
        }
    }

    //void OnGUI() {
    //    string velX = GetComponent<Rigidbody2D>().velocity.x.ToString();
    //    string velY = GetComponent<Rigidbody2D>().velocity.y.ToString();
    //    GUI.Label(new Rect(10, 10, 100, 20), "X: " + velX);
    //    GUI.Label(new Rect(10, 30, 100, 20), "Y: " + velY);
    //}

    float LimitRange(float value, float min, float max) {
        if (value <= min) { return min; } 
        else if (value >= max) { return max; }
        return value;
    }

    public void Kill() {
        MenuController mc = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuController>();
        lives--;
        UpdateLifeCounter();
        StartCoroutine(Invulnerability(InvulneravbilityDuration));
        if (lives < 1) {
            DestroyEntity();
            mc.EndGame();
        }
    }

    IEnumerator Invulnerability(float duration) {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        float startTime = Time.realtimeSinceStartup;
        float interval = 0.15f;
        isInvulnerable = true;

        // Blink
        while (Time.realtimeSinceStartup < startTime + duration) {
            if (sprite.enabled) { sprite.enabled = false; }
            else { sprite.enabled = true; }
            yield return new WaitForSeconds(interval);
        }
        sprite.enabled = true;
        isInvulnerable = false;
    }

    public void UpdateLifeCounter() {
        lifeCounter.text = lives.ToString();
    }
}
