using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event : MonoBehaviour
{
    public static UnityEvent<float> OnFinishTimer = new UnityEvent<float>();
    public static UnityEvent OnFinish = new UnityEvent();
    public static UnityEvent OnFailed = new UnityEvent();
    public static UnityEvent OnReset = new UnityEvent();

    public static void SendFinishTimer(float timer)
    {
        OnFinishTimer.Invoke(timer);
    }

    public static void SendFinish()
    {
        OnFinish.Invoke();
    }

    public static void Failed()
    {
        OnFailed.Invoke();
    }

    public static void GetReset()
    {
        OnReset.Invoke();
    }
}
