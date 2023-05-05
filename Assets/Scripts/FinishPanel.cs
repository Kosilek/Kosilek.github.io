using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPanel : MonoBehaviour
{
    private static float finishTime;

    private void Start()
    {
        finishTime = Finish.timerFinishPlayer;
    }
}
