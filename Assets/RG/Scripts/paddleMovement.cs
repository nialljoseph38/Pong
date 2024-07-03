using UnityEngine;
using Fidelity.DebugTools;
public class PaddleMovement : MonoBehaviour {
    public float speed;
    public Rigidbody body;
    public BallMovement ballMovement;
    void Update() {
        float v;
        if(transform.position.x < -5) {
            v = Input.GetAxisRaw("paddle_left");
        }
        else {
            v = Input.GetAxisRaw("paddle_right");
        }
        body.linearVelocity = new Vector2(0, (v * speed));

    }
    void OnCollisionEnter(Collision collision) {
        ballMovement.HorBounce();
    }
}
