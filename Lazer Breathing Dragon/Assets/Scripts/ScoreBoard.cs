using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    int score;
    Text scoretext;

    // Start is called before the first frame update
    void Start()
    {
        scoretext = GetComponent<Text>();
        scoretext.text = score.ToString();
    }

    public void ScoreHit( int pointsIncrease)
    {
        score += pointsIncrease;
        scoretext.text = score.ToString();
    }
}
