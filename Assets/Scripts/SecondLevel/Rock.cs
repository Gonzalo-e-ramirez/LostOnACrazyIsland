using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private RockData rockData;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementRock();
    }

    private void MovementRock(){
        transform.position = transform.position + rockData.direction  * rockData.speed * Time.deltaTime;
    }
    

   private void OnCollisionEnter(Collision other)
   {
     if(other.gameObject.tag == "Player"){
            animator.SetBool("Touch", true);
            GameManager.instance.LessLife();
            Destroy(gameObject, 0.2f);
        }else{ 
            if(other.gameObject.tag == "EndTrap"){
                animator.SetBool("Touch", true);
                Destroy(gameObject, 0.2f);
            }
        }
   }
}
