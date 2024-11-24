using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Mano")]
    [SerializeField] private Transform hand;
    [SerializeField] private float handDistance = 1.5f;

    private bool handFacingRight = true;

    [Header("Disparo")]
    [SerializeField] private GameObject handShootObjectPrefab;
    [SerializeField] private float shootSpeed = 10f;
    [SerializeField] private float shootRate = 0.5f;
    private float nextShootTime = 0f;

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 direction = mousePos - transform.position;

        hand.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        hand.position = transform.position + Quaternion.Euler(0, 0, angle) * new Vector3(handDistance, 0, 0);

        HandFlipController(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            HandleShooting(mousePos);
        }
    }

    private void HandleShooting(Vector3 mousePos)
    {

        if (Time.time >= nextShootTime)
        {
            Shoot(mousePos);

            nextShootTime = Time.time + shootRate;
        }
    }

    private void HandFlipController(Vector3 mousePos)
    {
        if (mousePos.x < transform.position.x && handFacingRight)
        {
            HandFlip();
        }
        else if (mousePos.x > transform.position.x && !handFacingRight)
        {
            HandFlip();
        }
    }

    private void HandFlip()
    {
        handFacingRight = !handFacingRight;

        hand.localScale = new Vector3(hand.localScale.x, hand.localScale.y * -1, hand.localScale.z);
    }

    private void Shoot(Vector3 mousePos)
    {
        Vector3 shootDirection = (mousePos - hand.position).normalized;

        GameObject projectile = Instantiate(handShootObjectPrefab, hand.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        rb.velocity = shootDirection * shootSpeed;

        Destroy(projectile, 5f);
    }
}
