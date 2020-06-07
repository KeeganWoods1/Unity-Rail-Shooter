using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] int addPointsInterval = 2;
    [SerializeField] int survivalScorePerInterval = 3;


    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.fixedTime;

        if ((currentTime % addPointsInterval) <= Mathf.Epsilon && !(currentTime <= Mathf.Epsilon))
        {
            scoreBoard.ScoreHit(survivalScorePerInterval);
        }
    }
}
