using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static float score;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (GameManager.playerLifes <= 0)
        {
            score = 0f;
        }
        else
        {
            score += 1 * Time.deltaTime;
            scoreText.text = "SCORE: " + Mathf.Round(score);
        }

    }
}
