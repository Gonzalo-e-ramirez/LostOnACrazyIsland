using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public event Action<String> OnTouchBoss;
    public static GameManager instance;
    public int life;
    public bool isWin;
    public int armo;
    private float timeTimer = 3.5f;
    public bool bossDead=false;
    [SerializeField] private TMP_Text armoNumber;
    [SerializeField] private GameObject[] lifeUI;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Camera cam;
    [SerializeField] private string nextLevel;
    [SerializeField] private string thisLevel;



    private void Awake() {
        if (instance != null)
        {
            Destroy(gameObject);
        }else
        {
            instance = this;
        }
    }

    void Update() {
        if(isWin){
            win.SetActive(true);
            cam.gameObject.SetActive(true);
        }

        armoNumber.text = ""+armo;

            
        if(bossDead){
            Temporizador();
        }
    }

    public void LessLife(){
        life--;
        if(life==2){
            lifeUI[life].SetActive(false);
        }else if(life ==1){
            lifeUI[life].SetActive(false);
        }else{
            lifeUI[life].SetActive(false);
            GameOver();
        }
    }
    public void GameOver(){
        gameOver.SetActive(true);
        cam.gameObject.SetActive(true);
        foreach (var lifeui in lifeUI)
        {
            lifeui.SetActive(false);
        }
    }

    public void LessArmo(){
        armo--;
    }

    public void PlusArmo(){
        armo++;
    }

    public void SelectReset(){
        SceneManager.LoadScene(thisLevel);
    }

    public void SelectNextLevel(){
        SceneManager.LoadScene(nextLevel);
    }

    public void SelectExit(){
        SceneManager.LoadScene("MainMenu");
    }

    public void AttackBoss(){
        OnTouchBoss?.Invoke("1");
    }

        private void Temporizador(){
        timeTimer-=Time.deltaTime;
        if(timeTimer<=0){
            isWin=true;
            }
            
        }
    }

