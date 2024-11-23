using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

public class ClickPlayer : MonoBehaviour
{
    [SerializeField] private Image clickBarFull;
     private float clickcount = 0;


    [SerializeField] private float timer;
    private float time = 0;



    void Update()
    {
        time += Time.deltaTime;
        if (time >= timer)
        {

            clickcount--;
            time = 0;
        }

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
