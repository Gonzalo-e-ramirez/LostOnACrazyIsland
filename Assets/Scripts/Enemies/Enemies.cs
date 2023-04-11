using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeOfEnemy{
    Look,
    Persuit,
    Attack,
    Walk
}

public class Enemies : Character
{
    [SerializeField] private Transform player;
    [SerializeField] private TypeOfEnemy enemyState;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private int index;
    [SerializeField] private EnemieData enemieData;
    private float timer=2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        State(enemyState);
    }

    private void State(TypeOfEnemy enemyState){

        switch (enemyState)
        {
            case TypeOfEnemy.Look:
                Look();
                break;
            case TypeOfEnemy.Persuit:
                Persuit();
                break;
            case TypeOfEnemy.Attack:
                Debug.Log("vacio");
                break;
            case TypeOfEnemy.Walk:
                Walk();
                break;
        }     
    }

        private void Persuit(){

        var playerVector = player.position - transform.position;
        var distanceToPlayer = playerVector.magnitude;
        if(distanceToPlayer<enemieData.distance){
            var newRotation = Quaternion.LookRotation(playerVector);
            transform.position += playerVector.normalized * (speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed* Time.deltaTime);
            animator.SetBool("Move", true);
        }else{
            animator.SetBool("Move", false);
        }
    }

        private void Look(){
        var playerVector = player.position - transform.position;
        var newRotation = Quaternion.LookRotation(playerVector);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed* Time.deltaTime);
    }

    private void Walk(){
        var nowWaypoint = waypoints[index];
        var difference = (nowWaypoint.position - transform.position);
        var direction = difference.normalized;
        transform.position += direction * (speed * Time.deltaTime);
        var newRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed* Time.deltaTime);
        var distance = difference.magnitude;

        if(distance <= enemieData.distanceThreshold){
            index++;
            if (index > waypoints.Length -1)
            {
            index=0;
            }
        }

    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.name == "Player"){
            if(timer <=0){
                GameManager.instance.LessLife();
                timer=2;
            }else{
                Temporizador();
            }
        }
    }

    private void Temporizador(){
        timer-=Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Player"){
             GameManager.instance.LessLife();
        }
    }

}
