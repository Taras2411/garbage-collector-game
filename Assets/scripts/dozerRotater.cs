using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class dozerRotater : MonoBehaviour
{
    public float speed = 1.0f;
    bool isLeft;
    // Start is called before the first frame update
    void Start()
    {
        isLeft = Random.value > 0.5f;
            
    }

    // Update is called once per frame
    void Update()
    {
        //get random bool 
        
        //if true rotate left
        if (isLeft)
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }else
        {
            transform.Rotate(Vector3.down * speed * Time.deltaTime);
        }

        
    }
}
