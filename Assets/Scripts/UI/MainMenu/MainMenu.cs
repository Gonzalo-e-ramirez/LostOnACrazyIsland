using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject[] menu;
    // Start is called before the first frame update 

    public void SelectStart(){
        SceneManager.LoadScene("FirstLevel");
    }

    public void SelectExit(){
        Application.Quit();
    }

    public void SelectButtons(){
        menu[0].SetActive(false);
        menu[1].SetActive(true);

    }

    public void SelectBack(){
        menu[0].SetActive(true);
        menu[1].SetActive(false);
    }
}
