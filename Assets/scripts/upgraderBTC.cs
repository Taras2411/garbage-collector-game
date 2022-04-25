using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgraderBTC : upgrader
{
    // Start is called before the first frame update
    
    public GameObject BTCText;
    public int changeToBtcLvl;
    public float BTCMultiplierPerLevel;
    public int BTCStartCost;
    GameObject BTC_Button;
    GameObject USD_Button;

    

    protected void Start()
    {
        Debug.Log("upgraderBTC");
        BTC_Button = BTCText.transform.parent.gameObject;
        USD_Button = cost_txt.transform.parent.gameObject;
        Debug.Log("usd:"+USD_Button + "btc:"+BTC_Button);
    }


    public void UpdateBtcCostText()
    {
        BTCText.GetComponent<Text>().text = (BTCStartCost + (BTCMultiplierPerLevel * current_level * BTCStartCost)).ToString();

    }
    //same as levelUp() but for BTC intead of USD
    public void levelUpBTC(){
        if (current_level < max_level && PlayerPrefs.GetInt("BTC",0) >= (BTCStartCost + (BTCMultiplierPerLevel * current_level * BTCStartCost)))
        {
            float temp = PlayerPrefs.GetInt("BTC",0) - (BTCStartCost + (BTCMultiplierPerLevel * current_level * BTCStartCost));
            PlayerPrefs.SetInt("BTC",(int)temp);
            current_level++;
            UpdateBtcCostText();
        }else if (PlayerPrefs.GetInt("BTC",0) < (BTCStartCost + (BTCMultiplierPerLevel * current_level * BTCStartCost))){
            DonateAndAdsMenu.SetActive(true);

        }
    }
    public void MakeUSDButtonActive()
    {
        USD_Button.SetActive(true);
        BTC_Button.SetActive(false);
    }
    public void MakeBTCButtonActive()
    {
        USD_Button.SetActive(false);
        BTC_Button.SetActive(true);
    }




}
