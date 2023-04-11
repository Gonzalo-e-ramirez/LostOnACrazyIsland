using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTrap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject trap;
    [SerializeField] private float timeTimer =7.0f;
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        Temporizador();
    }

      private void Temporizador(){
        timeTimer-=Time.deltaTime;
        if(timeTimer<=0){
             Instantiate(trap, gameObject.transform);
            timeTimer=3.0f;
        }
      }
}
