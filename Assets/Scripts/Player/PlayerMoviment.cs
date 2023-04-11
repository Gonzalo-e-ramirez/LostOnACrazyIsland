using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : Character
{

    private Vector3 moveDirection;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody body;
    public bool isGrounded;
    [SerializeField] private float timeTimer =3.0f;
    [SerializeField] private GameObject[] sight;
    private bool sightActive;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Temporizador();
        if(Input.GetButtonDown("Fire2")){
            if(sightActive){
                sight[0].SetActive(false);
                sight[1].SetActive(false);
                sightActive=false;
            }else{
                sight[0].SetActive(true);
                sight[1].SetActive(true);
                sightActive=true;
            }
        }
        if(Input.GetButtonDown("Fire1") && sightActive){
            Shoot();
        }
        if(GameManager.instance.isWin){
            gameObject.SetActive(false);
        }
        
    }
    

    private void moveCharacter(){
        //moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        transform.position += moveDirection * (Time.deltaTime * speed);
        //animación de caminar
        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        


        if(isGrounded && Input.GetButtonDown("Jump")){
            //moveDirection.y = jumpForce;
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("IsGrounded", true);
        }else{
            animator.SetBool("IsGrounded", false);
        }

        characterRotation();

    }

    private void characterRotation(){
            transform.Rotate(0,Input.GetAxis("Mouse X")*rotationSpeed,0);
            //Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.5f*Time.deltaTime);
    }

    private void Temporizador(){
        timeTimer-=Time.deltaTime;
        if(timeTimer<=0){
        moveCharacter();
        }
    }

    private void Shoot(){
        if(GameManager.instance.armo >0){
            
            GameManager.instance.armo--;
            GameObject newCoco;
            newCoco = Instantiate(bullet, bulletPosition.position, bulletPosition.rotation);
            newCoco.GetComponent<Rigidbody>().AddForce(bulletPosition.forward*1000);
            animator.SetTrigger("Throw");
            Destroy(newCoco, 2);
        }
    }
}
