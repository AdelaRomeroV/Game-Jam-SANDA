using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enemy ha tocado al jugador");
        }
    }
}




