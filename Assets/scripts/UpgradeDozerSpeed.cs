using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDozerSpeed : upgrader
{
    // Start is called before the first frame update
    public float value_incriment_per_level;


    
    void Start()
    {
        //get current level from playerprefs
        current_level = PlayerPrefs.GetInt("DozerSpeedLevel",0);
        updateCostText();
        //set player prefs USD to 10000
        
        // PlayerPrefs.SetInt("USD",10000);
    }

    // Update is called once per frame
    void Update()
    {
        //on level change update cost text
        if (current_level != PlayerPrefs.GetInt("DozerSpeedLevel",0))
        {
            updateCostText();
            PlayerPrefs.SetInt("DozerSpeedLevel",current_level);
        }

        current_value_txt.GetComponent<Text>().text = "X"+(1f+(value_incriment_per_level * current_level)).ToString();
        //set prefab bladeScale to current value
        PlayerPrefs.SetFloat("DozerSpeed",1f+(value_incriment_per_level * current_level));
        
    
    }
}
