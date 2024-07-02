using UnityEngine;

public class PaddleMovement : MonoBehaviour {
    public float speed;
    public string input_name;
    public Rigidbody body;
    void Update() {
        float v;
        if(input_name == "paddle_left") {
            v = Input.GetAxisRaw("paddle_left");
        }
        else if(input_name == "paddle_right") {
            v = Input.GetAxisRaw("paddle_right");
        }
        else {
            v = Input.GetAxisRaw("Horizontal");
        }
        body.linearVelocity = new Vector2(0, (v * speed));
    }
}
