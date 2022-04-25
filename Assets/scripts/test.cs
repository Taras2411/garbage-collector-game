using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int i = 999;

        switch (i)
        {
            case int n when (n >= 100):
                Debug.Log($"I am 100 or above: {n}");
                break;

            case int n when (n < 100 && n >= 50 ):
                Debug.Log($"I am between 99 and 50: {n}");
                break;

            case int n when (n < 50):
                Debug.Log($"I am less than 50: {n}");
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
