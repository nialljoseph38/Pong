using UnityEngine;

public class ballMovement : MonoBehaviour {
    public float init_speed;
    public Rigidbody body;
    float x;
    float y;
    float speedx;
    float speedy;
    void Start() {
        speedx = init_speed;
        speedy = init_speed;
    }
    void Update() {
        body.linearVelocity = new Vector3(speedx, speedy, 0);
    }
    void OnCollisionEnter(Collision collision) {
        x = transform.position.x;
        y = transform.position.y;
        if (y > 9 | y < 1) {
            speedy = -speedy;
        }
        if( x > 7 | x < -7) {
            speedx = -speedx;
        }
        if( x > 9 ) {
            score_left += 1;
            transform.position.x = 0;
            transform.position.y = 5;
        }
        if( x < -9) {
            score_right += 1;
            transform.position.x = 0;
            transform.position.y = 5;
        }
    }
}
