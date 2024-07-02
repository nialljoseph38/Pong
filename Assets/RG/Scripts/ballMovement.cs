using UnityEditor.U2D;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    public float init_speed;
    public Rigidbody body;
    public ScoreDisplay leftscore;
    public ScoreDisplay rightscore;
    public UIManager ui;
    float x;
    float y;
    public float speedx = 0;
    public float speedy = 0;
    float direction = 1;
    public void Begin() {
        if ( Random.Range(0, 2) == 1 ) {
            direction = -direction;
        }
        transform.position = new Vector3(0, 5, -5);
        speedx = Random.Range(5.0f, 10.0f);
        speedy = 10.0f - speedx;
        speedx = speedx * direction;
    }
    void Update() {
        body.linearVelocity = new Vector3(speedx, speedy, 0);
        x = transform.position.x;
        y = transform.position.y;
        if(x > 9) {
            Begin();
            leftscore.score_left += 1;
        }
        if(x < -9) {
            Begin();
            rightscore.score_right += 1;
        }
    }
    void OnCollisionEnter(Collision collision) {
        if (y > 9 | y < 1) {
            speedy = -speedy;
        }
        if ( x > 7 | x < -7) {
            speedx = -speedx;
        }
        
    }
}
