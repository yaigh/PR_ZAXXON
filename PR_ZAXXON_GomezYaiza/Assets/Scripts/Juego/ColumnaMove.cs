using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnaMove : MonoBehaviour
{
    float speed;

   

    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;
        
    }

    // Update is called once per frame
    void Update()
    {
      
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        float posZ = transform.position.z;
        if (posZ < -20)
        {
            Destroy(gameObject);
        }
    }

    

}
