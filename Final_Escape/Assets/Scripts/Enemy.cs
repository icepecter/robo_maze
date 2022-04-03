using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 pos;       
    public float move_max = 2.0f;     
    public float move_direction = 3.0f;
    public float move_flip_dis = 0.2f;
    public string move_positon = "x";
   

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        Vector3 v = pos;


        switch (move_positon)
        {
            case "x":
                v.x += move_max * Mathf.Sin(Time.time * move_direction);
                transform.position = v;

                if (v.x >= pos.x + move_max - move_flip_dis) transform.rotation = Quaternion.Euler(0, -90, 0); 
                else if (v.x <= pos.x - move_max + move_flip_dis) transform.rotation = Quaternion.Euler(0, 90, 0);
                break;

            case "z":
                v.z += move_max * Mathf.Sin(Time.time * move_direction);
                transform.position = v;

                if (v.z >= pos.z + move_max - move_flip_dis) transform.rotation = Quaternion.Euler(0, 180, 0);
                else if (v.z <= pos.z - move_max + move_flip_dis) transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }
}
