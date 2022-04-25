using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainObjectGen : MonoBehaviour
{
    public GameObject[] plus_prefabs;
    public int amoutOfPlus = 2;
    // public GameObject[] minus_prefabs;
    // public int amoutOfMinus = 2;

    void Start()
    {
        for(int i = 0; i < amoutOfPlus; i++){

            Vector3 size = GetComponent<Renderer>().bounds.size;
            GameObject chosenPrefab = plus_prefabs[Random.Range(0,plus_prefabs.Length)];
            if(chosenPrefab.GetComponent<Renderer>() != null){
                Vector3 chosenSize = chosenPrefab.GetComponent<Renderer>().bounds.size;
            }else
            {
                Vector3 chosenSize = chosenPrefab.GetComponentInChildren<Renderer>().bounds.size;
            }   
            Vector3 pos = new Vector3(Random.Range(-0.3f*size.x,0.3f*size.x), 30, Random.Range(-0.3f*size.z,0.3f*size.z));
            pos = pos + transform.parent.transform.position;
            //spawn prefab at random position in bounds of the terrain
            GameObject newObst = Instantiate(chosenPrefab, pos, Quaternion.Euler(0, 0, 0));
            newObst.transform.parent = transform;
        }
        //spawn a random minus prefab at a random position
        // for(int i = 0; i < amoutOfMinus; i++){
        
        //     Vector3 size = GetComponent<Renderer>().bounds.size;
        //     Vector3 pos = new Vector3(Random.Range(-0.3f*size.x,0.3f*size.x), 30, Random.Range(-0.3f*size.z,0.f*size.z));
        //     Debug.Log(pos + transform.position +"");

        //     GameObject newBottle = Instantiate(minus_prefabs[Random.Range(0, minus_prefabs.Length)], new Vector3(transform.position.x+pos.x,transform.position.y + pos.y,transform.position.z+pos.z), Quaternion.Euler(0, 0, 0));
        //     newBottle.transform.SetParent(transform);
        // }
    }

    void Update()
    {

    }
}
