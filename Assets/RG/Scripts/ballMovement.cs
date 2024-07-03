using UnityEditor.U2D;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    public float init_speed;
    public Rigidbody body;
    public ScoreDisplay leftscore;
    public ScoreDisplay rightscore;
    public float x_bound;
    public float y_bound;
    float x;
    float y;
    public float change_speed;
    public float speedx = 0;
    public float speedy = 0;
    float direction = 1;
    private void Start() {
        change_speed = init_speed;
    }
    public void Begin() {
        if(Random.Range(0, 2) == 1) {
            direction = -direction;
        }
        transform.position = new Vector3(0, 5, -5);
        speedx = Random.Range(init_speed, init_speed * 2);
        speedy = init_speed * 2 - speedx;
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
        if(change_speed != init_speed) {
            if(speedx > 0) {
                direction = 1;
            }
            else {
                direction = -1;
            }
            init_speed = change_speed;
            speedx = Random.Range(init_speed, init_speed * 2);
            speedy = init_speed * 2 - speedx;
            if(speedx > 0) {
                speedx = speedx * direction;
            }
        }
    }
    void OnCollisionEnter(Collision collision) {
        if(y > y_bound + 5) {
            speedy = -Mathf.Abs(speedy);
        }

        if(y < 5 - y_bound) {
            speedy = Mathf.Abs(speedy);
        }
    }
    public void HorBounce() {
        if(x > x_bound) {
            speedx = -Mathf.Abs(speedx);
        }

        if(x < -x_bound) {
            speedx = Mathf.Abs(speedx);
        }
    }
}

