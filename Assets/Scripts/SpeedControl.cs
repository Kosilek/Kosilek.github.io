using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    public static float speedOne;
    public static float speedTwo;

    [SerializeField] private int lineSegmentOne;
    [SerializeField] private int lineSegmentTwo;

    private void Awake()
    {
        Event.OnReset.AddListener(Reset);
    }

    private void Update()
    {
        GetLineSegment();
        RecalculationSpeedOne();
        RecalculationSpeedTwo();

    }

    void RecalculationSpeedOne()
    {
        speedOne = lineSegmentOne / 20;
    }

    void RecalculationSpeedTwo()
    {
        speedTwo = (lineSegmentTwo * speedOne)/lineSegmentOne;
    }

    void GetLineSegment()
    {
        lineSegmentOne = MouseNavi.lineSegment;
        lineSegmentTwo = MouseNavi2.lineSegment;
    }



    public void Reset()
    {
        lineSegmentOne = 0;
        lineSegmentTwo = 0;
        speedOne = 0;
        speedTwo = 0;
    }

}
