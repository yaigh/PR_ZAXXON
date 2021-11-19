using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInical : MonoBehaviour
{  
    
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    public void IniciarJuego()
    {
        GameManager.playerLifes = 3;
        SceneManager.LoadScene(1);
    }


    /*
    public void IniciarHud()
    {
        SceneManager.LoadScene(4);
    }
    public void IniciarHighScore()
    {
        SceneManager.LoadScene(3);
    }
    public void IniciarJuego()
    {
       GameManager.playerLifes = 3;
       SceneManager.LoadScene(1);
    }
    public void IniciarConfig()
    {
       SceneManager.LoadScene(2);
    }
    public void MenuInicio()
    {
        SceneManager.LoadScene(0);
    }
    */



}
