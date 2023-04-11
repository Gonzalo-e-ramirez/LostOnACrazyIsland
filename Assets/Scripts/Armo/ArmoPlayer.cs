using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoPlayer : MonoBehaviour
{

    [SerializeField] private GameObject coco;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.C)){
            Instantiate(coco);
        }
        
    }
}
