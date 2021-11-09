using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumenUI : MonoBehaviour
{
    [SerializeField] Text volumenText;
    int volumen;
    [SerializeField] Slider mySlider;

    // Start is called before the first frame update
    void Start()
    {
        volumenText.text = "MUSIC:" + mySlider.value;
    }

    // Update is called once per frame
    void Update()
    {
       
        volumen = ((int)mySlider.value);
        volumenText.text = "MUSIC:" + volumen;
        
    }
        

}
