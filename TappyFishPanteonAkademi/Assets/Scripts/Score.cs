using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    Text scoreText;
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text  = score.ToString();
    }

    public void Scored()
    {
        score ++;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
