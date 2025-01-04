using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGiverController : MonoBehaviour
{
    [SerializeField] private float life;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LifeController lifeController = collision.GetComponent<LifeController>();
            lifeController.gainLife(life);
            Destroy(gameObject);
        }
    }
}
