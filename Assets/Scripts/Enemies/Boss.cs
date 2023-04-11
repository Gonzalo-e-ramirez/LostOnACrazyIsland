using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss : Character
{

    [SerializeField] private GameManager mg;
    [SerializeField] private float timeTimer =1.0f;
    private bool timerOn=false;
    [SerializeField] private Transform player;
    [SerializeField] private int distance;
    [SerializeField] private GameObject volume;

    // Start is called before the first frame update
    void Start()
    {
        mg.OnTouchBoss+=LessLife;
    }

    void Update() {
        if(timerOn){
            Temporizador();
        }else{
            Persuit();
        }
        
    }

    // Update is called once per frame

    public void LessLife(string log){
        life--;
        animator.SetBool("Damage", true);
        timerOn=true;
        if(life<=0){
            timeTimer=3;
            timerOn=true;
            animator.SetBool("Dead", true);
            Destroy(gameObject, 2);
            GameManager.instance.bossDead=true;
        }
    }

    public void TouchPlayer(){
        animator.SetBool("Attack", true);
        GameManager.instance.LessLife();
    }

    private void Temporizador(){
        timeTimer-=Time.deltaTime;
        if(timeTimer<=0){
            animator.SetBool("Damage", false);
            animator.SetBool("Attack", false);
            volume.SetActive(false);
            timerOn=false;
            timeTimer =1.5f;
        }
    }
   
    private void OnTriggerStay(Collider other)
    {
        if(timerOn==false){
            if(other.gameObject.tag == "Player"){
            TouchPlayer();
            volume.SetActive(true);
            timerOn=true;
        }
        
        }
        
    }


    private void Persuit(){

        var playerVector = player.position - transform.position;
        var distanceToPlayer = playerVector.magnitude;
        if(distanceToPlayer - 1 <distance){
            var newRotation = Quaternion.LookRotation(playerVector);
            transform.position += playerVector.normalized * (speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed* Time.deltaTime);
            animator.SetBool("Move", true);
        }else{
            animator.SetBool("Move", false);
        }
    }

}
