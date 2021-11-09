using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInical : MonoBehaviour
{
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
}
