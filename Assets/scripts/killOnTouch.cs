using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killOnTouch : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    GameObject canvas;
    public bool permanent = false;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        foreach (Transform child in transform){
            if(child.GetComponent<killOnTouch> () == null){
                //add mesh collider and rigidbody to children if they dont have one
                if(child.GetComponent<MeshCollider>() == null){
                    child.gameObject.AddComponent<MeshCollider>();
                    //make mesh collider convex
                    child.GetComponent<MeshCollider>().convex = true;

                }
                child.gameObject.AddComponent<killOnTouch>();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("collided with " + other.gameObject.tag);
        if (other.gameObject.tag == "Dozer"){
            //delete all parrents of this object
            Destroy(gameObject);

            if(!permanent){
            player.GetComponent<playerController>().HealthDown(1);    

            //get highest parent with KillOnTouch script and delete it
            Transform parent = gameObject.transform.parent;
            if(parent == null){
                Destroy(gameObject);
            }else if(parent.GetComponent<killOnTouch>() != null){
            
           
            Destroy(parent.gameObject);
            }

            

            }else{
                player.GetComponent<playerController>().HealthDown(player.GetComponent<playerController>().playerHealth);
            }
        }
    }
}
