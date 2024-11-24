using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    [Header("Puntuación")]
    public int score = 0;

    [Header("UI")]
    [SerializeField] public TextMeshProUGUI scoreText;

    void Start()
    {
        ActualizarPuntuacion();
    }

    public void AddScore(int points)
    {
        score += points;
        ActualizarPuntuacion();
    }

    private void ActualizarPuntuacion()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
