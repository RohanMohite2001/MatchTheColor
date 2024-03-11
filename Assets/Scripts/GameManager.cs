using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    private int score = 0;
    
    private void Awake()
    {
        Instance = this;
    }
    
    
    public void AddScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }
    
    public void SubstractScore()
    {
        score -= 1;
        scoreText.text = score.ToString();
    }
}
