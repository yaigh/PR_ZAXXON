using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NaveMove : MonoBehaviour
{

    [SerializeField] float deplSpeed;
    //[SerializeField] float rotationSpeed;
    [SerializeField] float limitH;
    [SerializeField] float limitY;
    [SerializeField] float suelo;
    
    [SerializeField] Transform navePos;
    [SerializeField] GameObject bola;
    

    
    InitGame initGame;
    

    [SerializeField] Image lifesImage;
    [SerializeField] Sprite[] lifesSprite;

    int lifes;

    // Start is called before the first frame update
    void Start()
    {
        initGame = GameObject.Find("InitGame").GetComponent<InitGame>();
        deplSpeed = 25f;
        //rotationSpeed = 150f;

        limitH = 20f;
        limitY = 12f;
        suelo = 0;
       
        if(GameManager.playerLifes <= 0)
        {
            SceneManager.LoadScene(0);
        }
            
        lifes = GameManager.playerLifes;
        lifesImage.sprite = lifesSprite[lifes];



    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (initGame.alive)
        {
            MoverNarve();
        }
        */
        MoverNave();
        Disparar();

        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene(5);
        }
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



        //transform.Rotate(0f, 0f, desplR * Time.deltaTime * rotationSpeed);

        //Desplazamientos

        //transform.Translate(Vector3.right * Time.deltaTime * deplSpeed * desplX, Space.World);

        //transform.Translate(Vector3.up * Time.deltaTime * deplSpeed * desplY, Space.World);


        transform.Translate(Vector3.back * Time.deltaTime * deplSpeed * desplZ, Space.World);


        //transform.Rotate(0f, 0f, desplR * Time.deltaTime * rotationSpeed);

        transform.rotation = Quaternion.Euler(desplY * -30, 0, desplX * -30);


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
        
        if (other.gameObject.layer == 6)
        {
            Chocar(other.gameObject);
                    

        }
    }

  void Disparar()
    {
        
        Vector3 destPost = navePos.position;

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bola, destPost, Quaternion.identity);
            
        }
        
        
    
    }

    void Chocar(GameObject otro)
    {
        GameManager.playerLifes--;

        if (GameManager.playerLifes == 0)
        {
            StartCoroutine("TiempoEspera");

            
        }
        else
        {
            lifes = GameManager.playerLifes;
            lifesImage.sprite = lifesSprite[lifes];
            initGame.spaceshipSpeed = 30f;
            Destroy(otro);
            //int currentScene = SceneManager.GetActiveScene().buildIndex;
            //SceneManager.LoadScene(currentScene);
        }
    }
  IEnumerator TiempoEspera()
  {
        
        initGame.spaceshipSpeed = 0f;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(4);
  }
   
}
