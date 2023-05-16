using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeScale : MonoBehaviour
{
    public Slider slideTime;

    private void Awake()
    {
        slideTime = FindObjectOfType<Slider>();
    }
    private void Update()
    {
        Time.timeScale = slideTime.value;
    }
}
