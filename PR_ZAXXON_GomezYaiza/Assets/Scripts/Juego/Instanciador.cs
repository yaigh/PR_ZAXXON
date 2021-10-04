using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instanciador : MonoBehaviour
{

    float intervalo;
    [SerializeField] GameObject obstaculo;
    [SerializeField] Transform instanciarPos;

    float desplX = 5f;
    
    


    // Start is called before the first frame update
    void Start()
    {
        intervalo = 1f;

        StartCoroutine("CrearObstaculos");

        Vector3 destPos = instanciarPos.position;
        Vector3 despl = new Vector3(desplX, 0, 0);


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
            float randomX = Random.Range(-10f, 10f);
            Vector3 newPos = new Vector3(randomX, instanciarPos.position.y, instanciarPos.position.z);
            Instantiate(obstaculo, newPos, Quaternion.identity);

            yield return new WaitForSeconds(intervalo);
        }
    }
}
