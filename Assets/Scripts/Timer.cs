using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float maxTime;
    [SerializeField] Slider sliderTimer;
    [SerializeField] TypingManager Typing;
    float myTime;

    TIMER_STATUS status;

    public enum TIMER_STATUS
    {
        WAITING,
        RUNNING
    }

    // Start is called before the first frame update
    void Start()
    {
        status = TIMER_STATUS.WAITING;
    }

    // Update is called once per frame
    void Update()
    {
        if ( status == TIMER_STATUS.RUNNING)
        {
            float rate = 0.0f;
            myTime -= Time.deltaTime;
            
            if ( myTime > 0.0f)
            {
                rate = myTime / maxTime;
                sliderTimer.value = rate;

                // Debug.Log(rate);

                

            }
            else
            {
                sliderTimer.value = rate;
                status = TIMER_STATUS.WAITING;

                Typing.timeUp();
            }
        }
    }

    public void StartTimer(float _maxTime)
    {
        maxTime = _maxTime;
        myTime = maxTime;
        status = TIMER_STATUS.RUNNING;

        Debug.Log("StartTimer called");
    }

    public void StopTimer()
    {
        status = TIMER_STATUS.WAITING;
    }
}
