using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{


    [SerializeField] private float enemySpeed;
    [SerializeField] private float enemyRotation;
    [SerializeField] private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;


    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);

        Vector2 direction = (player.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, enemyRotation * Time.deltaTime);


    }
}




