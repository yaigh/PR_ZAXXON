using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instanciador : MonoBehaviour
{

    float intervalo;

    //[SerializeField] GameObject obstaculo;
    //[SerializeField] GameObject[];
    [SerializeField] Transform instanciarPos;
    [SerializeField] GameObject[] obstaculos;
    
    
    

    float limiteL = -18f;
    float limiteR = 18f;

    float limiteU = 12f;
    float limiteD = 0f;


    // Start is called before the first frame update
    void Start()
    {
        intervalo = 1f;


        StartCoroutine("CrearObstaculos");
        /*
        Vector3 destPos = instanciarPos.position;
        Vector3 despl = new Vector3(desplX, 0, 0);
        */
        
        //transform.position = new Vector3(0f, 0f, 0f);

        /*for (int n= 0; n < 5; n++)
        {
           
            Instantiate(obstaculo, destPos, Quaternion.identity);
            destPos = destPos + despl;
        }
        */

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CrearObstaculos()
    {
       

        while (true)
        {
            

            float randomX = Random.Range(limiteL, limiteR);
            Vector3 newPositionX = new Vector3(randomX, instanciarPos.position.y, instanciarPos.position.z);

            int numAleatorioX = Random.Range(0, obstaculos.Length);
            Instantiate(obstaculos[numAleatorioX], newPositionX, Quaternion.identity);


            float randomY = Random.Range(limiteU, limiteD);
            Vector3 newPositionY = new Vector3(instanciarPos.position.x, randomY, instanciarPos.position.z);

            int numAleatorioY = Random.Range(0, obstaculos.Length);
            Instantiate(obstaculos[numAleatorioY], newPositionY, Quaternion.identity);


            yield return new WaitForSeconds(intervalo);
        }
    }
}
