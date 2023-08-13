using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    private int speed;
    [SerializeField]
    private int rotationSpeed;
    [SerializeField]
    private int jumpingPower;
    [SerializeField]
    private float flyPower;
    [SerializeField]
    private GameObject explosionEffect;


    private Rigidbody2D rb;
    private bool isGround=true;
    private float currentYPosition;
    
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        currentYPosition=transform.position.y;
        isGround=false;
    }

    void Update() 
    {
        if(Input.GetMouseButtonDown(0) && GameManager.Instance.CurrentState==GameState.OnJump && isGround)
        {
            rb.AddForce(new Vector2(rb.velocity.x,jumpingPower));
            var currentRotZ=transform.localEulerAngles.z;
            
            transform.LeanRotateZ(currentRotZ+180f,rotationSpeed);
            
        }
        else if(Input.GetMouseButton(0) && GameManager.Instance.CurrentState==GameState.OnGravity)
        {
            
            rb.velocity=new Vector2(rb.velocity.x,currentYPosition+flyPower);
            currentYPosition=transform.position.y;
        }
    }

    void FixedUpdate()
    {
        transform.position+=new Vector3(speed*Time.deltaTime,0,0);
    }
     private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag=="Ground")
        {
            isGround=true;
        }
        else if(other.gameObject.GetComponent<Enemy>())
        {
            gameObject.SetActive(false);
            Instantiate(explosionEffect,transform.position,Quaternion.identity);
            GameManager.Instance.UpdateGameState(GameState.Fail);
        }
        
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.tag=="Ground")
        {
            isGround=false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name=="1St Zone Finish")
        {
            GameManager.Instance.UpdateGameState(GameState.OnGravity);
            rb.gravityScale=.5f;
        }
        else if(other.gameObject.tag=="Finish")
        {
            GameManager.Instance.UpdateGameState(GameState.Succes);
        }
        
    }
  
}
