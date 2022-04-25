using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDozerShield : upgraderBTC
{
    // Start is called before the first frame update
    public float value_incriment_per_level;
    void Start()
    {   
        base.Start();
        //get current level from playerprefs
        current_level = PlayerPrefs.GetInt("DozerShieldLevel",0);
        updateCostText();
        UpdateBtcCostText();

    }

    // Update is called once per frame
    void Update()
    {
        if (current_level >= changeToBtcLvl){
            MakeBTCButtonActive();
        }
        else
        {
            MakeUSDButtonActive();
        }
        //on level change update cost text
        if (current_level != PlayerPrefs.GetInt("DozerShieldLevel",0))
        {
            updateCostText();
            UpdateBtcCostText();
            PlayerPrefs.SetInt("DozerShieldLevel",current_level);
        }
        current_value_txt.GetComponent<Text>().text = "X"+((value_incriment_per_level * current_level)).ToString();
        //set prefab DozerShield to current value
        PlayerPrefs.SetInt("DozerShield",(int)(value_incriment_per_level * current_level));

    }
}
