using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatforms : MonoBehaviour
{


    [SerializeField] private Transform[] waypoints;
    [SerializeField] private int index;
    [SerializeField] private int distanceThreshold=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move(){
        var nowWaypoint = waypoints[index];
        var difference = (nowWaypoint.position - transform.position);
        var direction = difference.normalized;
        transform.position += direction * (2 * Time.deltaTime);
        //var newRotation = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2* Time.deltaTime);
        var distance = difference.magnitude;

        if(distance <= distanceThreshold){
            index++;
            if (index > waypoints.Length -1)
            {
            index=0;
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        other.gameObject.transform.SetParent(transform);
    }

    void OnCollisionExit(Collision other)
    {
        other.gameObject.transform.SetParent(null);
    }

}
