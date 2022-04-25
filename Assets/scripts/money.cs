using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour
{
    // Start is called before the first frame update
    public Text usdText;
    public Text btcText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        usdText.text = PlayerPrefs.GetInt("USD").ToString();
        btcText.text = PlayerPrefs.GetInt("BTC").ToString();
    }
}
