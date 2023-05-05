using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathControll : Singelton<PathControll>
{
    public static int i = 0;


    public static float speedOne;
    public static float speedTwo;

    [SerializeField] public static int lineSegmentOne;
    [SerializeField] public static int lineSegmentTwo;
    protected override void Awake()
    {
        base.Awake();
    }

   // private void Start()
   // {
   //     i = 0;
  //  }


    

    public static void Check()
    {
       
        if (i <2)
        i += 1;
        Debug.Log($"i = {i}");
    }
}
