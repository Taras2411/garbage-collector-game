using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgrader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cost_txt;
    public GameObject current_value_txt;
    public int start_cost;
    public float cost_multiplier_per_level;
    
    public int max_level;
    public int current_level;
    public GameObject DonateAndAdsMenu;

    void start()
    {

    }

    

    public void updateCostText()
    {
        cost_txt.GetComponent<Text>().text = (start_cost + (cost_multiplier_per_level * current_level * start_cost)).ToString();
    }

    public void levelUp()
    {
        
        if (current_level < max_level && PlayerPrefs.GetInt("USD",0) >= (start_cost + (cost_multiplier_per_level * current_level * start_cost)))
        {
            
            float temp = PlayerPrefs.GetInt("USD",0) - (start_cost + (cost_multiplier_per_level * current_level * start_cost));
            
            PlayerPrefs.SetInt("USD",(int)temp);
            current_level++;
            updateCostText();
        }else if (PlayerPrefs.GetInt("USD",0) < (start_cost + (cost_multiplier_per_level * current_level * start_cost))){
            DonateAndAdsMenu.SetActive(true);
        }

    }

}
