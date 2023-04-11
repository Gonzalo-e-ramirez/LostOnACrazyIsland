using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    public GameObject trap;
    private float timeTimer =3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {

      if(other.tag == "Player"){
        Temporizador();
      }
        
    }

      private void Temporizador(){
        timeTimer-=Time.deltaTime;
        if(timeTimer<=0){
             Instantiate(trap);
            timeTimer=5.0f;
        }
      }
}
