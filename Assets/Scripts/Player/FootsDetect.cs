using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootsDetect : MonoBehaviour
{

    public PlayerMoviment player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        player.isGrounded = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        player.isGrounded = false;
    }
}
