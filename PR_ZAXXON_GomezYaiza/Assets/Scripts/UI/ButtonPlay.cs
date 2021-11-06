using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        IniciarJuego();

    }
    public void IniciarJuego()
    {
        if (Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene("PrimeraScena");
        }
    }
}
