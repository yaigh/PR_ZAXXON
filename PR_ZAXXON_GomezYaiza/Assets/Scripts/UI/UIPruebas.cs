using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIPruebas : MonoBehaviour
{
    //Pruebas de vidas con imagenes (imagen y sprite)


    [SerializeField] Image livesImage;
    [SerializeField] Sprite lives0;

    static int lives;
    [SerializeField] Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Space")) 
        {
           
        }
    }

    void Morir()
    {
        lives--;
        livesImage.sprite = spriteArray[lives];

    }
}
