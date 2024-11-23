using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtletaSpawnScript : MonoBehaviour
{
    public GameObject atletaPrefab;
    public Transform[] atletaSpawn;
    public float intervaloMin = 1f;
    public float intervaloMax = 3f;


    void Start()
    {
        GenerarEnemigo();
    }

    void Update()
    {
        intervaloMin = Mathf.Max(0.5f, intervaloMin - Time.deltaTime * 0.01f);
        intervaloMax = Mathf.Max(1f, intervaloMax - Time.deltaTime * 0.01f);
    }
    private void GenerarEnemigo()
    {
        int indiceAleatorio = Random.Range(0, atletaSpawn.Length);
        Transform puntoSeleccionado = atletaSpawn[indiceAleatorio];

        Instantiate(atletaPrefab, puntoSeleccionado.position, Quaternion.identity);

        float siguienteIntervalo = Random.Range(intervaloMin, intervaloMax);
        Invoke(nameof(GenerarEnemigo), siguienteIntervalo);
    }
}
