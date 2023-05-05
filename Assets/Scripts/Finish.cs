using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private float timerStart = 0;
    public static float timerFinishPlayer;
    public Sprite[] finishSkins;

    private void Start()
    {
            switch (Character.finishSelect)
            {
                case 0:
                    gameObject.GetComponent<SpriteRenderer>().sprite = finishSkins[0];
                    break;
                case 1:
                    gameObject.GetComponent<SpriteRenderer>().sprite = finishSkins[1];
                    break;
            }
    }

    private void Update()
    {
        timerStart += Time.deltaTime;
        Debug.Log(PathControll.i);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            timerFinishPlayer = timerStart;
            Event.SendFinishTimer(timerFinishPlayer);
            Event.SendFinish();
            NaviControl.checkEnd = false;
            NaviControl.speed = 0;
            NaviControl2.checkEnd = false;
            NaviControl2.speed = 0;
            PathControll.i = 0;
            MouseNavi.lineSegment = 0;
            MouseNavi2.lineSegment = 0;
        }
    }
}
