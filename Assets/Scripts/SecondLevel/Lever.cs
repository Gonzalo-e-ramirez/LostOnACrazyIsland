using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject stopObject;
    [SerializeField] private GameObject ui;
    [SerializeField] private Animator animator;
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
        ui.SetActive(true);
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)){
            stopObject.gameObject.SetActive(false);
             animator.SetTrigger("Touch");
        }
    }

    private void OnTriggerExit(Collider other) {
        ui.SetActive(false);
    }

}
