using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;

public class NaviControl2 : MonoBehaviour
{
    public static float speed;
    Rigidbody rb;
    public static bool checkEnd;
    private Animator anim;
    //public AnimatorController anim2;
    //public AnimatorController anim4;
    public RuntimeAnimatorController anim2;
    public RuntimeAnimatorController anim4;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        switch (Character.playersSelect)
        {
            case 0:
                anim.GetComponent<Animator>().runtimeAnimatorController = anim2;
                break;
            case 1:
                anim.GetComponent<Animator>().runtimeAnimatorController = anim4;
                break;
        }
    }

    private void FixedUpdate()
    {
        Character.SetAnimRun(anim, speed);
        if (!MouseNavi.isDone) return;
        if (PathControll.i == 2)
        {
            if (checkEnd)
            {
                speed = SpeedControl.speedTwo;
            }
            Character.Run(transform, rb, speed, 2); 
        }
    }

   
}
