using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CocoInTheFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Player"){
            GameManager.instance.PlusArmo();
            Destroy(this.gameObject);
        }else if(other.gameObject.tag=="enemies"){
            Destroy(other.gameObject);
        }else if(other.gameObject.tag=="Boss"){
            GameManager.instance.AttackBoss();
        }
            
    }

}
