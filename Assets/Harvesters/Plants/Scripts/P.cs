using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    private Slider slider;


    private float Fillspeed = 0.05f;
    private float targetProgress = 0;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }


    //Start is called before the first frame update
    private void Start()
    {
        IncrementProgress(1f);
    }

    //Update is called once per frame
    private void Update()
    { 
        if (slider.value < targetProgress)
            slider.value += Fillspeed * Time.deltaTime;
       
    }

    public void IncrementProgress(float NewProgress)
    {
       targetProgress = slider.value + NewProgress;
    }


}
