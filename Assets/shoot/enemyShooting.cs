using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotDir;
    private float timeShot;
    public float startTime;
    public float offset;
    Transform player;
    bool angry = false;
    bool chill = true;

    public float angryDistance;
    public float chillDistance;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < angryDistance)
        {
            angry = true;
            chill = false;
        }
        if (Vector2.Distance(transform.position, player.position) > chillDistance)
        {
            angry = false;
            chill = true;
        }
        if (angry == true)
        {
            Angry();
        }
        if (chill == true)
        {
            Chill();
        }
   
    }
    void Angry()
    {
         Vector3 difference = player.transform.position - transform.position;
         float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

          if (timeShot <=0)
         {
              Instantiate(bullet, shotDir.position, transform.rotation);
              timeShot = startTime;
          }
          else
          {
             timeShot -= Time.deltaTime;
          }
    }
    void Chill()
    {

    }


    }