using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instBolas : MonoBehaviour
{
    [SerializeField] GameObject bolaInst;
    [SerializeField] Transform posInst;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          
       if (Input.GetKeyDown("space"))
        {
            Instantiate(bolaInst, posInst);
          
        }

        
    }



      
}
