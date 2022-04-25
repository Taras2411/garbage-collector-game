using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstThrower : MonoBehaviour
{
    Rigidbody rb;
    GameObject player;
    Animator anim;
    public float throwForce = 5;
    Collider m_Collider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player =  GameObject.FindGameObjectsWithTag("Player")[0];
        anim = player.transform.Find("RotationCenter").GetComponent<Animator>();
        m_Collider = GetComponent<Collider>();
        if (m_Collider == null)
        {
            m_Collider = GetComponentInChildren<Collider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dozer"){
            m_Collider.enabled = false;
            Collider[] colliders = GetComponentsInChildren<Collider>();
            if (colliders != null)
            {
                foreach (Collider c in colliders)
                {
                    c.enabled = false;
                }
            }


            Vector3 throwVector = new Vector3(Random.Range(-0.5f,0.5f),1,Random.Range(-0.25f,0.25f));
            //generate randome torque vector in ramge -1 1 -1 1 -1 1
            Vector3 torqueVector = new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f));
            rb.AddForce(throwVector * throwForce, ForceMode.Impulse);
            rb.AddTorque(torqueVector * throwForce, ForceMode.Impulse);
            anim.Play("throw",0,0.0f);


            }
    }
}
