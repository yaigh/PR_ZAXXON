using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasDisparos : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * Time.deltaTime * 15f);
        
        if (transform.position.z > 80)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
