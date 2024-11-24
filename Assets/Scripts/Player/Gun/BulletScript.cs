using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{
    [Header("Puntuación")]
    public int puntosPorMatar = 10;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            ScoreManagerScript scoreManager = FindObjectOfType<ScoreManagerScript>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(puntosPorMatar);
            }

            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
