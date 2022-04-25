using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainGen : MonoBehaviour
{
    // Start is called before the first frame update
    public int amountOfPrefabs;
    public GameObject prefab;
    public GameObject[] contaminatedPrefabs;
    public GameObject[] bonusPrefabs;
    private float lastPosZ ;
    private float lastPosX;
    private float lastPosY;
    public int CurrentAmmount;
    public float contaminatedPrefabChance = 10f;
    public float bonusPrefabChance = 10f;
    void Start()
    {

        lastPosZ = transform.position.z;
        lastPosX = transform.position.x;
        lastPosY = transform.position.y;


    }

    // Update is called once per frame
    private GameObject previosInst = null;
    int i = 0;
    void FixedUpdate()
    {
        if ((previosInst == null || previosInst.GetComponentInChildren<Renderer>().isVisible)){
            GameObject newPrefab;





            // if (Random.Range(0.0f, 100.0f)<contaminatedPrefabChance && prefab != null){
            //     newPrefab = Instantiate(contaminatedPrefabs[Random.Range(0,contaminatedPrefabs.Length)], new Vector3(lastPosX, lastPosY, lastPosZ),Quaternion.Euler(0, 0, 0));
            // }else{             
            //     newPrefab = Instantiate(prefab, new Vector3(lastPosX, lastPosY, lastPosZ),Quaternion.Euler(0, 0, 0));
            // }
            //same as above, but using switch case
            int randomValue = Random.Range(0, 100);
            switch (randomValue)
            {
                case int n when (n <= bonusPrefabChance):
                    // Debug.Log($"I am between 0 and {bonusPrefabChance}: {n}");
                    newPrefab = Instantiate(bonusPrefabs[Random.Range(0, bonusPrefabs.Length)], new Vector3(lastPosX, lastPosY, lastPosZ), Quaternion.Euler(0, 0, 0));
                    break;
                case int n when (n > bonusPrefabChance && n <= bonusPrefabChance + contaminatedPrefabChance):
                    // Debug.Log($"I am between {bonusPrefabChance} and {bonusPrefabChance + contaminatedPrefabChance}: {n}");
                    newPrefab = Instantiate(contaminatedPrefabs[Random.Range(0, contaminatedPrefabs.Length)], new Vector3(lastPosX, lastPosY, lastPosZ), Quaternion.Euler(0, 0, 0));
                    break;
                default:
                    // Debug.Log("I am default: " + randomValue);
                    newPrefab = Instantiate(prefab, new Vector3(lastPosX, lastPosY, lastPosZ), Quaternion.Euler(0, 0, 0));
                    break;
                
            }
            //disable object generating script on the first generted prefab 
            if (previosInst == null){
                newPrefab.GetComponentInChildren<terrainObjectGen>().enabled = false;
            }

            previosInst = newPrefab;
            Vector3 size =  newPrefab.GetComponentInChildren<Renderer>().bounds.size;

            lastPosZ += size.z;
            CurrentAmmount++;  
            i++;
        }

        
    }
}
