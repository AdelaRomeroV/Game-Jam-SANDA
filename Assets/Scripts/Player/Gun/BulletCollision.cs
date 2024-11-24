using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private float damage = 20;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            LifeController life = collision.GetComponent<LifeController>();
            life.lossLife(damage);

        }


        if (collision.CompareTag("Atleta"))
        {
            LifeController life = collision.GetComponent<LifeController>();
            life.lossLife(damage);

        }
    }



}
