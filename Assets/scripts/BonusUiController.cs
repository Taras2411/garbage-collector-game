using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusUiController : MonoBehaviour
{

    public GameObject Shields;
    public GameObject Player;
    playerController pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = Player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pc.playerHealth >= 1)
        {

            //find text component in children and set text to player health
            foreach (Transform child in Shields.transform)
            {
                if (child.GetComponent<Text>() != null)
                {
                    child.GetComponent<Text>().text = (pc.playerHealth-1).ToString();
                }
            }
        }

    }
}
