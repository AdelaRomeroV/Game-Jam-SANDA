using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public float life; //Vida actual
    public float maxLife; //Vida max
    private void Start()
    {
        life = maxLife;
    }

    public void lossLife(float loss)
    {
        life -= loss;

        if (life < 0)
        {

            Debug.Log("Player has lost all of his life"); //aca ya cambiariamos depende de la situacion

        }
    }

    public void gainLife(float gain) //Just in case you know?
    {

        life += gain;
        if (life > maxLife)
        {
            life = maxLife;

        }

    }
}
