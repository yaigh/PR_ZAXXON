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

    [SerializeField] GameObject explosion;
    [SerializeField] GameObject naveObject;



    InitGame initGame;
    

    [SerializeField] Image lifesImage;
    [SerializeField] Sprite[] lifesSprite;

    int lifes;

    AudioSource audioSource;
    [SerializeField] AudioClip disparo;
    [SerializeField] AudioClip explosionAudio;

    [SerializeField] Renderer materialAgua;

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

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1f;


        materialAgua.material.SetFloat("Vector1_50b60d7ab20c41c194679adaac9c6ddb", -2);

        naveObject.SetActive(true);

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


        //Variable para restricci?n

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


        //Variable para restricci?n

        /*
        Primer intento de restricci?n
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
            audioSource.PlayOneShot(disparo, 1f);
        }
        
        
    
    }

    void Chocar(GameObject otro)
    {
        GameManager.playerLifes--;

        if (GameManager.playerLifes == 0)
        {
            StartCoroutine("TiempoEspera");
            //Paro el agua
            materialAgua.material.SetFloat("Vector1_50b60d7ab20c41c194679adaac9c6ddb", 0);
            audioSource.PlayOneShot(explosionAudio, 1f);
            Instantiate(explosion, navePos.position, Quaternion.identity);
            naveObject.SetActive(false);
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
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(4);
  }
   
}
