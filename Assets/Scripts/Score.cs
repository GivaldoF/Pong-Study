using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _score = 0;
    public static Action OnScored;
    TextMeshProUGUI _scoreText;
    
    private void Awake()
    {
        OnScored += AddScore;
        _scoreText = GetComponent<TextMeshProUGUI>() ?? 
                     throw new NullReferenceException("TextMeshProUGUI component not found on Score object");
    }

    void AddScore()
    {
        _score++;
        _scoreText.text = _score.ToString("D5");
    }
}
