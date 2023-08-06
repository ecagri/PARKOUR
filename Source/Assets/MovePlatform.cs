using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;

    private int currentWayPoint = 0;

    private float speed = 8f;

    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWayPoint%2].transform.position, transform.position) < .1f){
            currentWayPoint++;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPoint%2].transform.position, Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.name == "Player"){
            coll.gameObject.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D coll){
        if(coll.gameObject.name == "Player"){
            coll.gameObject.transform.SetParent(null);
        }
    }
}
