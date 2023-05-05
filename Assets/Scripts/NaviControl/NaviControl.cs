
using UnityEngine;
using System.Collections;
using UnityEngine.Animations;
//using UnityEditor.Animations;

public class NaviControl : MonoBehaviour {

    public static float speed;
    Rigidbody rb;
    public static bool checkEnd;
    private Animator anim;
  //  public AnimatorController anim2;
   // public AnimatorController anim3;
    public RuntimeAnimatorController anim1;
    public RuntimeAnimatorController anim3;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        switch (Character.playersSelect)
        {
            case 0:
                anim.GetComponent<Animator>().runtimeAnimatorController = anim1;
                break;
            case 1:
                anim.GetComponent<Animator>().runtimeAnimatorController = anim3;
                break;
        }

    }

    private void FixedUpdate()
    {
        Debug.Log(Character.playersSelect);
        Character.SetAnimRun(anim, speed);
        if (!MouseNavi.isDone) return;
        if (PathControll.i == 2)
        { 
            if (checkEnd)
            {
                if (NaviControl2.speed != 0)
                speed = SpeedControl.speedOne;
            }
            Character.Run(transform, rb, speed, 1);
            //rb.MovePosition(transform.position + MouseNavi.direction.normalized * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "block")
        {
            Debug.Log("qqq");
        }
    }
}
