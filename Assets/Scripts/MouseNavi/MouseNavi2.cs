using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseNavi2 : MonoBehaviour
{

    public GameObject gPlayer;
    public Transform ground;
    public float step;
    public Transform dot;
    public Transform finish;

    private Vector3 position;
    private List<Transform> path = new List<Transform>();
    private static bool _done;
    private bool checkingFinish = false;
    private bool hitPlayer;
    private Transform player;
    private static Vector3 _dir;
    private int index;

    public static int lineSegment = 0;
    public static Vector3 direction
    {
        get { return _dir; }
    }

    public static bool isDone
    {
        get { return _done; }
    }

    void AddDot(Vector3 curPos, Vector3 normal)
    {

        Transform t = Instantiate(dot) as Transform;
        t.position = curPos;
        t.rotation = Quaternion.FromToRotation(Vector3.up, normal);
        path.Add(t);
        lineSegment++;
    }

    void DoAction()
    {
        if (isDone) return;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform != finish)
            {
                if (hit.transform == gPlayer.transform)
                {
                    player = hit.transform;
                    position = hit.transform.position;
                    hitPlayer = true;
                }

                if (hitPlayer && hit.transform == ground)
                {
                    float dist = Vector3.Distance(position, hit.point);

                    if (dist >= step)
                    {
                        position = hit.point;
                        AddDot(hit.point + hit.normal * 0.5f, hit.normal);
                    }
                }
            }
            else if (hit.transform == finish)
            {
                checkingFinish = true;
                _done = true;
                hitPlayer = false;


            }
        }
    }

    void UpdatePath()
    {
        if (index == path.Count)
        {
            index = 0;
            path = new List<Transform>();
            _done = false;
        }

        if (!isDone) return;

        _dir = path[index].position - player.position;
        float dist = Vector3.Distance(path[index].position, player.position);
        if (dist <= 0.1f)
        {
            Destroy(path[index].gameObject);
            index++;
        }
    }

    void Update()
    {
      
            if (Input.GetMouseButton(0))
            {
                DoAction();
            }
            else if (Input.GetMouseButtonUp(0) && checkingFinish == false)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    Destroy(path[i].gameObject);
                }
                path.Clear();
                hitPlayer = false;
                lineSegment = 0;
            }
            else if (Input.GetMouseButtonUp(0) && checkingFinish == true)
            {
                if (path.Count > 0)
                {

                    NaviControl2.checkEnd = true;
                PathControll.Check();
                // checkingFinish = false;
            }

        }
        

        UpdatePath();
    }
}
