using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float CurrentTime;
    [SerializeField] private float DisplayTime;
    [SerializeField] private TMP_Text displayText;

    void Update()
    {
        if(CurrentTime >= 180)
        {
            displayText.text = "Game Over";
        }
        else
        {
            displayText.text = Time.time.ToString("F2");
        }
     
    }
}

