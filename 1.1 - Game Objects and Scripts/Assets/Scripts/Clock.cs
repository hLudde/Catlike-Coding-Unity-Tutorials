using System;
using UnityEngine;
public class Clock : MonoBehaviour{

    const float degreesPerHour = 30f;
    const float degreesPerMinute = 6f;
    const float degreesPerSeconds = 6f;

    public Transform hoursTransform, minutesTransform, secondsTransform;
    public bool continuous;

    void Update(){
        if(continuous){
            UpdateContinuous();
        }else{
            UpdateDiscrete();
        }
    }

    void UpdateContinuous() {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSeconds, 0f);
    }

    void UpdateDiscrete() {
        DateTime time = DateTime.Now;
        hoursTransform.localRotation = Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, time.Second * degreesPerSeconds, 0f);
    }
}