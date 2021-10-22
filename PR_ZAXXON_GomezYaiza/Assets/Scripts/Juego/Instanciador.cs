using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instanciador : MonoBehaviour
{

    float intervalo;

    [SerializeField] Transform instanciarPos;
    [SerializeField] GameObject[] obstaculos;

    [SerializeField] float distance;
  
    [SerializeField] float posZcolumna1;

    float limiteL = -20f;
    float limiteR = 20f;

    float limiteU = 12f;
    float limiteD = 0f;

    InitGame initGame;
    // Start is called before the first frame update
    void Start()
    {
        distance = 30f;
        posZcolumna1 = 150f;
        initGame = GameObject.Find("InitGame").GetComponent<InitGame>();

        StartCoroutine("CrearObstaculos");

        CrearColumnasIniciales();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CrearObstaculos()
    {

        float speed;
        while (true)
        {
            speed = initGame.spaceshipSpeed;
            intervalo = distance / speed;

            int numAleatorioX = Random.Range(0, obstaculos.Length);
            int numAleatorioY = Random.Range(0, obstaculos.Length);

            float randomX;
            float randomY;

            if (obstaculos[numAleatorioX].tag != "pared")
            {
                randomX = Random.Range(limiteL, limiteR);
            }
            else
            {
                randomX = 0f;
            }

            if (obstaculos[numAleatorioY].tag != "pared")
            {
                randomY = Random.Range(limiteU, limiteD);
            }
            else
            {
                randomY = 0f;
            }


            Vector3 newPositionX = new Vector3(randomX, instanciarPos.position.y, instanciarPos.position.z);
            Instantiate(obstaculos[numAleatorioX], newPositionX, Quaternion.identity);


           
            Vector3 newPositionY = new Vector3(instanciarPos.position.x, randomY, instanciarPos.position.z);
            Instantiate(obstaculos[numAleatorioY], newPositionY, Quaternion.identity);


            yield return new WaitForSeconds(intervalo);
        }
    }

    void CrearColumnasIniciales()
    {

        float posZ = instanciarPos.position.z;
        float columnasIniciales = (posZ - posZcolumna1) / distance;

        columnasIniciales = Mathf.Round(columnasIniciales);
        //print(columnasIniciales);

        for (float n = posZcolumna1; n < posZ; n += distance)
        {
            float randomX = Random.Range(limiteL, limiteR);
            Vector3 columnaInicialPos = new Vector3(randomX, instanciarPos.position.y, n);
            Instantiate(obstaculos[0], columnaInicialPos, Quaternion.identity);
        }
    }
}
