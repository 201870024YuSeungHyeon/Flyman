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
        if (isValue == false) // 부스터 꺼졌을 때
        {
            CurrentValue += 0.0005f; // 게이지 증가
        }
        else if (isValue == true) // 부스터 켜졌을 때
        {
            CurrentValue -= 0.0005f; // 게이지 감소
        }

        if (CurrentValue < 0) // 부스터 수치 방지턱
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
