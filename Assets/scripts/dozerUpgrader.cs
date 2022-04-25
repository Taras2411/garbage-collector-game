using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dozerUpgrader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blade;
    playerController pc;

    void Awake()
    {
        blade.transform.localScale = new Vector3(1, PlayerPrefs.GetFloat("bladeScale",1),1);
        pc = GetComponent<playerController>();
        pc.playerSpeed = PlayerPrefs.GetFloat("DozerSpeed",1) * pc.InputPlayerSpeed;
        pc.StartPlayerHealth = PlayerPrefs.GetInt("DozerShield",0)+1;
    }
    void Start()
    {
        //Set USD and BTC palyer prefs to 100000
        //TESTING PURPOSES

        // if(PlayerPrefs.GetInt("USD",0) == 0)
        // {
        //     PlayerPrefs.SetInt("USD",100000);
        // }

        // if(PlayerPrefs.GetInt("BTC",0) == 0)
        // {
        //    PlayerPrefs.SetInt("BTC",100000);
        // }
        
        //END TESTING PURPOSES
        



    }

    // Update is called once per frame
    void Update()
    {
        //updta blade scale if playerpref changed
        if (PlayerPrefs.GetFloat("bladeScale",1) != blade.transform.localScale.y)
        {
            blade.transform.localScale = new Vector3(1, PlayerPrefs.GetFloat("bladeScale",1),1);
        }
        //update dozer speed if playerpref changed
        if (PlayerPrefs.GetFloat("DozerSpeed",1)*pc.InputPlayerSpeed != pc.playerSpeed)
        {
            pc.playerSpeed = PlayerPrefs.GetFloat("DozerSpeed",1) * pc.InputPlayerSpeed;
        }
        //update dozer shieldAmount if playerpref changed
        if (PlayerPrefs.GetInt("DozerShield",0)+1 != pc.StartPlayerHealth)
        {
            
        }

    }
}
