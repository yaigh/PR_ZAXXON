using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NaveMove : MonoBehaviour
{

    [SerializeField] float deplSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float limitH;
    [SerializeField] float limitY;
    [SerializeField] float suelo;
    
    [SerializeField] Transform navePos;
    //[SerializeField] Transform cannon;
    [SerializeField] GameObject bola;
    //[SerializeField] BalasDisparos bolaPlayer;

    
    InitGame initGame;
    /*
    [SerializeField] GameObject bala;
    [SerializeField] Transform cannon;
    */


    // Start is called before the first frame update
    void Start()
    {
        initGame = GameObject.Find("InitGame").GetComponent<InitGame>();
        deplSpeed = 25f;
        rotationSpeed = 150f;

        limitH = 20f;
        limitY = 12f;
        suelo = 0;

    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();

        Disparar();

    }


    void MoverNave()
    {
        float desplX = Input.GetAxis("Horizontal");
        float desplY = Input.GetAxis("Vertical");
        float desplZ = Input.GetAxis("Profundidad");
        float desplR = Input.GetAxis("Rotation");

        float posX = transform.position.x;
        float posY = transform.position.y;


        //Variable para restricción

        if ((posX < limitH || desplX < 0f) && (posX > -limitH || desplX > 0f))
        {
            transform.Translate(Vector3.right * Time.deltaTime * deplSpeed * desplX, Space.World);
        }

        if ((posY < limitY || desplY < 0f) && (posY > suelo || desplY > 0f))
        {
            transform.Translate(Vector3.up * Time.deltaTime * deplSpeed * desplY, Space.World);
        }



        transform.Rotate(0f, 0f, desplR * Time.deltaTime * rotationSpeed);

        //Desplazamientos

        //transform.Translate(Vector3.right * Time.deltaTime * deplSpeed * desplX, Space.World);

        //transform.Translate(Vector3.up * Time.deltaTime * deplSpeed * desplY, Space.World);


        transform.Translate(Vector3.back * Time.deltaTime * deplSpeed * desplZ, Space.World);


        transform.Rotate(0f, 0f, desplR * Time.deltaTime * rotationSpeed);

        //Variable para restricción

        /*
        Primer intento de restricción
        if(posX > limitH && desplX > 0f)
        {
            transform.position = new Vector3(18f, transform.position.y, transform.position.z);
        }
        else if (posX > - limitH && desplX > 0f)
        {
            transform.position = new Vector3(18f, transform.position.y, transform.position.z);
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("He chocado con" + other.gameObject.tag);
        


        if (other.gameObject.layer == 6)
        {
            initGame.spaceshipSpeed = 0f;
            SceneManager.LoadScene("PrimeraScena");

        }
    }

  void Disparar()
    {
       
        Vector3 destPost = new Vector3(navePos.position.x, navePos.position.y, navePos.position.z);

        if (Input.GetKeyDown("space"))
        {
            Instantiate(bola, destPost, Quaternion.identity);
            
        }
        
        
    
    }
  
   
}
