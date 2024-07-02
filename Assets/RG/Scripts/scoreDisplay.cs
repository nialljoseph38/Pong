using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    public int score_left = 0;
    public int score_right = 0;
    public TMP_Text score_text;
    public string score_side;

    void Update() {
        if (score_side == "right") {
            score_text.SetText(score_right.ToString());
        }
        else if (score_side == "left") {
            score_text.SetText(score_left.ToString());
        }


    }
}
