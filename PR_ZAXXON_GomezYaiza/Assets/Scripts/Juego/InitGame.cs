using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitGame : MonoBehaviour
{
    public float spaceshipSpeed = 30f;
    public bool alive;

    //[SerializeField] Text speedText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spaceshipSpeed += 0.001f;
        float veloc = (spaceshipSpeed * 3600) / 1000;
        //speedText.text = "S: " + Mathf.Round(veloc) + "Km/h";
    }
}
