using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

public class ClickPlayer : MonoBehaviour
{
    [SerializeField] private Image clickBarFull;
    [SerializeField] private float maxClicks;
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
        clickBarFull.fillAmount = Mathf.Lerp(clickBarFull.fillAmount ,clickcount / maxClicks, Time.deltaTime * 20f);
    }

    void ClickCounter()
    {
        
        if (Input.GetMouseButtonDown(0))
        {

            clickcount++;
        }
    }
}
