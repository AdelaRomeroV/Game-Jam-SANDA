using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeBar : MonoBehaviour
{
    private LifeController lifeController;

    [SerializeField] private Image lifeBarFull;


    private void Update()
    {
        lifeController = FindAnyObjectByType<LifeController>();
        lifeBarFull.fillAmount = lifeController.life / lifeController.maxLife;

    }
}
