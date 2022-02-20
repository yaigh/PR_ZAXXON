using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;

    
    [SerializeField] Slider volumeSlider;
   

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = GameManager.musicVolume;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMusicVolume()
    {
        
        float setVolume = Mathf.Log10(volumeSlider.value) * 20;
        mixer.SetFloat("Musica", setVolume);
        GameManager.musicVolume = volumeSlider.value;
    }

    
}
