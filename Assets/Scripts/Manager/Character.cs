using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Singelton<Character>
{

    public static int playersSelect;
    public static int finishSelect;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerPrefs.HasKey(SkinsPlayerSelect.playerSelect))
        {
            playersSelect = PlayerPrefs.GetInt(SkinsPlayerSelect.playerSelect);
        }

        if (PlayerPrefs.HasKey(SkinsFinichSelect.finishSelect))
        {
            finishSelect = PlayerPrefs.GetInt(SkinsFinichSelect.finishSelect);
        }
        NaviControl.checkEnd = false;
        NaviControl.speed = 0;
        NaviControl2.checkEnd = false;
        NaviControl2.speed = 0;
        PathControll.i = 0;
        MouseNavi.lineSegment = 0;
        MouseNavi2.lineSegment = 0;
    }

    static public void Run(Transform transform, Rigidbody rb, float speed, int i)
    {
        switch(i)
        {
            case 1:
                rb.MovePosition(transform.position + MouseNavi.direction.normalized * speed * Time.deltaTime);
                break;
            case 2:
                rb.MovePosition(transform.position + MouseNavi2.direction.normalized * speed * Time.deltaTime);
                break;
        }
    }

    static public void SetAnimRun(Animator anim, float speed)
    {
        anim.SetFloat("speed", Mathf.Abs(speed));
    }


}
