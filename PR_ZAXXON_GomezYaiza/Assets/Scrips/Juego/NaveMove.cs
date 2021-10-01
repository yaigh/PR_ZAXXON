using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMove : MonoBehaviour
{

    [SerializeField] float deplSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float limitH;
  

    // Start is called before the first frame update
    void Start()
    {
        deplSpeed = 10f;
        rotationSpeed = 100f;
        limitH = 18f;
    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
    }


    void MoverNave()
    {
        float desplX = Input.GetAxis("Horizontal");
        float desplY = Input.GetAxis("Vertical");
        float desplZ = Input.GetAxis("Profundidad");
        float desplR = Input.GetAxis("Rotation");

        float posX = transform.position.x;

        //Variable para restricción

        if ((posX < limitH || desplX < 0f) && (posX > - limitH || desplX > 0f))
        {
            transform.Translate(Vector3.right * Time.deltaTime * deplSpeed * desplX, Space.World);
        }


        //Desplazamientos

        //transform.Translate(Vector3.right * Time.deltaTime * deplSpeed * desplX, Space.World);

        transform.Translate(Vector3.up * Time.deltaTime * deplSpeed * desplY, Space.World);


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


}
