using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTakeController : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LifeController lifeController = collision.GetComponent<LifeController>();
            lifeController.lossLife(damage);
            Destroy(gameObject);
        }
    }
}
