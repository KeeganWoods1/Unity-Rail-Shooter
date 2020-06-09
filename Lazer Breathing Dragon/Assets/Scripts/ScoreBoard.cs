using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] int addPointsInterval = 2;
    [SerializeField] int survivalScorePerInterval = 3;

    int score;
    Text scoretext;
    float endGameTime = 100f;

    // Start is called before the first frame update
    void Start()
    {
        scoretext = GetComponent<Text>();
        scoretext.text = score.ToString();
    }

    void Update()
    {
        AddSurvivalPoints();

    }

    private void AddSurvivalPoints()
    {
        float currentTime = Time.fixedTime;

        if ((currentTime % addPointsInterval) <= Mathf.Epsilon 
            && !(currentTime <= Mathf.Epsilon) 
            && !(currentTime >= endGameTime))
        {
            ScoreHit(survivalScorePerInterval);
        }
    }

    public void ScoreHit( int pointsIncrease)
    {
        score += pointsIncrease;
        scoretext.text = score.ToString();
    }
}
