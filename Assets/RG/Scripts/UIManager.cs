using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour {
    public Canvas canvas;
    public BallMovement ball;
    float xspeed;
    float yspeed;
    public void Start() {
        ball.speedx = 0;
        ball.speedy = 0;
        canvas.enabled = false;
        canvas.enabled = true;
    }
    public void StartGame() {
        canvas.enabled = false;
        ball.Begin();
        ball.leftscore.score_left = 0;
        ball.rightscore.score_right = 0;
    }
    public void Continue() {
        canvas.enabled = false;
        ball.speedx = xspeed;
        ball.speedy = yspeed;
    }
    public void Exit() {
        Application.Quit();
    }
    private void Update() {
        if(Input.GetKeyDown("escape") == true && canvas.enabled) {
            canvas.enabled = false;
            ball.speedx = xspeed;
            ball.speedy = yspeed;
        }
        else if(Input.GetKeyDown("escape") == true && canvas.enabled == false) {
            xspeed = ball.speedx;
            yspeed = ball.speedy;
            ball.speedx = 0;
            ball.speedy = 0;
            canvas.enabled = true;
        }
    }

}
