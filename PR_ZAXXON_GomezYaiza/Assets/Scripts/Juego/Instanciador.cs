using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instanciador : MonoBehaviour
{

    float intervalo;
    [SerializeField] GameObject columna;
    [SerializeField] Transform intanciarPos;

    // Start is called before the first frame update
    void Start()
    {
        intervalo = 1f;
        StartCoroutine("CrearColumnas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CrearColumnas()
    {
        while (true)
        {
            Instantiate(columna, intanciarPos);
            yield return new WaitForSeconds(intervalo);
        }
    }
}
