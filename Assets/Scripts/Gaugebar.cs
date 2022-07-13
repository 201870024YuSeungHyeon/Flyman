using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gaugebar : MonoBehaviour
{

    public Slider slider;
    public Text displaytext;
    private float currentValue = 0f;
  
   
    void Start()

    {
        
        CurrentValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentValue += 0.0043f;

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
