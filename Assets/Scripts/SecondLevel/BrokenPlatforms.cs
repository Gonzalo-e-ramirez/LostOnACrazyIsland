using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatforms : MonoBehaviour
{

    [SerializeField] private float timeTimer =0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay(Collision other)
    {

                if (other.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            Temporizador();
        }
        
    }

        private void Temporizador(){
        timeTimer-=Time.deltaTime;
        if(timeTimer<=0){
        Destroy(gameObject);
        }
    }
}
