using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainDestr : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    void Start()
    {
        player =  GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame

    void Update()
    {   
        
        
        
        if(transform.position.z < player.transform.position.z - GetComponentInChildren<Renderer>().bounds.size.z*2){
            Destroy(gameObject);
            if(transform.parent != null){
                Destroy(transform.parent.gameObject);
            }
        }

        
    }
}
