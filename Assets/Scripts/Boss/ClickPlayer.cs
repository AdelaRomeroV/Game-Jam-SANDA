using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

public class ClickPlayer : MonoBehaviour
{
    [SerializeField] private Image clickBarFull;
     private float clickcount = 0;


    void Update()
    {
        ClickCounter();
        clickBarFull.fillAmount = clickcount / 100f;
    }

    void ClickCounter()
    {
        
        if (Input.GetMouseButtonDown(0))
        {

            clickcount++;
        }
    }
}
