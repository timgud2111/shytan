using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroler : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float startWaitTime;
    public float stoppingDistance;
    public float distanceStop;
    public float retreatDistance;
    public Transform[] moveSpots;
    private int randomSpot;
    Transform player;
    bool angry = false;
    bool chill = true;
    bool stop = false;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);

    }

    void Update()
    {
        
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            stop = false;
        }
        if (Vector2.Distance(transform.position, player.position) < distanceStop)
        {
            angry = false;
            stop = true;
        }

        if (angry == true)
        {
            Angry();
        }
            if (chill == true)
        {
            Chill();
        }
            if (stop == true)
        {
            Stop();
        }
    }
   
    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    void Chill()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
          if (waitTime <=0)
        {
          randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
        }
        else
        {
          waitTime -= Time.deltaTime;
        }
        }
    }
    void Stop()
    {
        if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
    }
}
