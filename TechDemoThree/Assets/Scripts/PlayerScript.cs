using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rigid;
    private Vector2 movement;
    public GameObject target;
    public bool pressing;
    public bool cantUnTarg;
    public GameObject atckBut;
    public bool damage;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        // Get input from arrow keys
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");

        // Calculate movement direction
        movement = new Vector2(horizontalInput, verticalInput);

        // Normalize movement to ensure consistent speed in all directions

        if(Input.GetMouseButtonDown(0) && !cantUnTarg)
        {
            pressing = true;
            
        }
        else
        {
            pressing = false;
        }
        
    }

    void FixedUpdate()
    {
        movement.Normalize();

        // Move the player
        rigid.MovePosition(rigid.position + movement * speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        cantUnTarg = true;
    }

    private void OnMouseUp()
    {
        cantUnTarg = false;
    }
    public void autoAttack()
    {
        if (target != null)
        {
            damage = true;
        }
            
    }
}
