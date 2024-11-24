using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamageEffect : MonoBehaviour
{
    [SerializeField] private Material MaterialHit;

    [SerializeField] private float TiempoHit;

    private SpriteRenderer spriteRenderer;

    private Material Original;

    private Coroutine HitCoroutine;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Original = spriteRenderer.material;
    }

    private IEnumerator HitRoutine()
    {
        spriteRenderer.material = MaterialHit;
        yield return new WaitForSeconds(TiempoHit);
        spriteRenderer.material = Original;
        HitCoroutine = null;

    }

    public void HitFlash()
    {
        if (HitCoroutine != null)
        {
            StopCoroutine(HitCoroutine);


        }

        HitCoroutine = StartCoroutine(HitRoutine());

    }
}
