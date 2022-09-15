using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI scoreUI;
    private int score;

    private void Start()
    {
        score = 0;
        scoreUI = GetComponent<TextMeshProUGUI>();    
    }

    private void Update()
    {
        if (score < 0)
        {
            scoreUI.text = "Game over";
        }
        else
        {
            scoreUI.text = score.ToString();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void PlusScore()
    {
        score += 1;

        if (score > 10)
        {
            score = 10;
        }
    }

    public void MinusScore()
    {
        score -= 1;
    }
}