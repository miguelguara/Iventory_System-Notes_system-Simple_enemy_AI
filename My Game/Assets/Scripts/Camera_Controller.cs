using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    Transform PPosition;
    float Cam_speed;

    void Start()
    {
        PPosition = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(PPosition.position.x, PPosition.position.y+1.80f,transform.position.z);

        float distance = Vector2.Distance(transform.position, dir);
        if (distance >= 2f)
        {
            Cam_speed = 5;
        }
        else
        {
            Cam_speed = 7;
        }

        transform.position = Vector3.MoveTowards(transform.position,dir,Cam_speed* Time.deltaTime);
    }

}
