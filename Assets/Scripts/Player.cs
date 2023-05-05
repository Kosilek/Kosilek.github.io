using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null || collision.gameObject.GetComponent<Wall>() != null)
        {
            Event.Failed();
            NaviControl.checkEnd = false;
            NaviControl.speed = 0;
            NaviControl2.checkEnd = false;
            NaviControl2.speed = 0;
            Destroy(gameObject.GetComponent<Player>());
        }
    }
}
