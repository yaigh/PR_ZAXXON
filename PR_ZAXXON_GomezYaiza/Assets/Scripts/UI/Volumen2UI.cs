using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Volumen2UI : MonoBehaviour
{
    [SerializeField] Text volumenText;
    float volumen;
    [SerializeField] Slider mySlider;

    // Start is called before the first frame update
    void Start()
    {
        volumenText.text = "SOUND EFFECTS:" + mySlider.value;
    }

    // Update is called once per frame
    void Update()
    {

        volumen = (mySlider.value);
        volumenText.text = "SOUND EFFECTS:" + volumen;

    }
}
