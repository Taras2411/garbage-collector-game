using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstPoints : MonoBehaviour
{
    // Start is called before the first frame update
    public int points;
    public int btc_points;
    GameObject Canvas;
    GameObject scoreText;
    bool isActive;
    void Start()
    {
        Canvas = GameObject.FindGameObjectsWithTag("Canvas")[0];
        scoreText = GameObject.Find("ScoreText").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dozer" && isActive == false){
            scoreText.GetComponent<hudController>().score += points;
            isActive = true;
            //increase USD player prefs by points
            PlayerPrefs.SetInt("USD", PlayerPrefs.GetInt("USD") + points);
        }    


    }
}
