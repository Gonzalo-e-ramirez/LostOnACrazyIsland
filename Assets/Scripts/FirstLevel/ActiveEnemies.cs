using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemies : MonoBehaviour
{
    [SerializeField] private float distanceRay;
    [SerializeField] private Transform point;
    [SerializeField] private GameObject enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(point.position, point.right * distanceRay, Color.red);
        RaycastHit hit;
        if(Physics.Raycast(point.position, point.right, out hit, distanceRay)){
            if(hit.transform.name=="Player"){
                enemies.SetActive(true);
            }
        }
    }
}
