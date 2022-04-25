using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private CharacterController controller;
    public float InputPlayerSpeed;
    public float playerSpeed;
    public int StartPlayerHealth;
    public int playerHealth;
    public int speedBoost;
    public float immoitabilityTime = 0.5f;
    public GameObject shield;

    public float speedIncrease = 0.1f;
    private Vector3 playerVelocity;
    private float gravity  = -9.81f * 1000;
    private Animator anim;
    float lastHitTime;
    GameObject canvas;
    [SerializeField] private hudController hudController;
    
    // Start is called before the first frame update
  

    void Start()
    {

        canvas = GameObject.Find("Canvas");
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        playerSpeed = InputPlayerSpeed;
        playerHealth = StartPlayerHealth;
    }

    // Update is called once per frame
    float HorizontalScreenInput;
    void Update()
    {   
        if(playerHealth > 1){
            shield.SetActive(true);
            //change shield material color to green 
            shield.GetComponent<Renderer>().material.color = Color.HSVToRGB(map(playerHealth,1f,10f,0.5f,1f),1f , 0.75f);
            // Debug.Log("shield is active" + map(playerHealth,1f,10f,0.5f,1f) + "   " + playerHealth + "color"+ Color.HSVToRGB(map(playerHealth,1f,10f,0.5f,1f),1f , 0.75f));
        }else{
            shield.SetActive(false);
        }

        if(playerHealth <= 0){
            // Debug.Log("Game Over");
            canvas.GetComponent<canvasControler>().changeActiveState(true);
            gameObject.GetComponent<playerController>().enabled = false; 
        }

        //add 10 playerSpeed on shift key press
        // float HorizontalScreenInput = 0f;
        

        //animation
        anim.SetFloat("Speed", Input.GetAxis("Vertical"));

        if (Input.touchCount > 0)
        {        
            Touch touch = Input.GetTouch(0);
            HorizontalScreenInput = (touch.position.x/Screen.width)*2f-1f;
        }else{
            //slowly change HorizontalScreenInput to 0
            HorizontalScreenInput = Mathf.Lerp(HorizontalScreenInput, 0f, 0.1f);
        }

        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(0, 0, 1f);
        move =  Quaternion.Euler(0, HorizontalScreenInput*45, 0) * move;
        transform.LookAt(transform.position + Quaternion.Euler(0, HorizontalScreenInput*45, 0) * Vector3.left);
        controller.Move(move * Time.deltaTime * (playerSpeed+speedIncrease*hudController.score));
        
        playerVelocity.y += gravity * Time.deltaTime;
        
        controller.Move(playerVelocity * Time.deltaTime);
    }
    public void HealthDown(int damage)
    {
        if(Time.time - lastHitTime > immoitabilityTime){
            playerHealth -= damage;
            lastHitTime = Time.time;
        }
       
        if (playerHealth <= 0)
        {
            playerHealth = 0;
        }

    }
    public void HealthUp(int heal)
    {
        playerHealth += heal;
    }    
    
    float map(float s, float a1, float a2, float b1, float b2)
    {
    return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }
}
