using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gaugebar : MonoBehaviour
{

    public Slider slider;
    public Text displaytext;
    private float currentValue = 0f;
    public bool isValue = false;
   
    void Start()
    {
        CurrentValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isValue == false)
        {
            CurrentValue += 0.0005f;
        }
        else if (isValue == true)
        {
            CurrentValue -= 0.0005f;
        }

        if (CurrentValue < 0)
        {
            CurrentValue = 0;
        }
        else if (CurrentValue > 1)
            CurrentValue = 1;
    }

    public float CurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            currentValue = value;
            slider.value = currentValue;
            displaytext.text = (slider.value * 100).ToString("0.00") + "%";
        }
    }
}
