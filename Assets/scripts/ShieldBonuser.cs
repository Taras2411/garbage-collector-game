using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBonuser : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //on trigger enter, get player health and set it to player health + 1
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dozer")
        {
            playerController pc = player.gameObject.GetComponent<playerController>();
            pc.playerHealth += 1;
            Destroy(gameObject);
        }
    }
}
