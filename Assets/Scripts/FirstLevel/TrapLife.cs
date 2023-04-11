using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLife : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5.0f);
    }

    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.name == "Player"){
            gameOver.SetActive(true);
            cam.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
        
    }
}
