using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoovingWall : MonoBehaviour
{
    [SerializeField] private float moov;
    [SerializeField] private float positionMin;
    [SerializeField] private float positionMax;
    private bool moovLeft;

    private void Update()
    {
        if (moovLeft)
        {
            transform.position = new Vector3(transform.position.x - moov * Time.deltaTime, transform.position.y, transform.position.z);
        } else if (!moovLeft)
        {
            transform.position = new Vector3(transform.position.x + moov * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if (transform.position.x <= positionMin)
        {
            moovLeft = false;
        } else if (transform.position.x >= positionMax)
        {
            moovLeft = true;
        }
    }

}
