using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Target : MonoBehaviour
{
    private Vector2 followSpot;
    public float speed = 5f;
    public float persectiveScale;
    public Animator  anim; 
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    void Start()
    {
       followSpot = transform.position;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       //followSpot = PlayerMemory.HasSavedPosition ? PlayerMemory.LastPosition : transform.position;

       
    }

    
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

         // ← не забудь вверху!

    void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            // НЕ ставим точку, если клик по UI
            if (EventSystem.current.IsPointerOverGameObject()) return;

            followSpot = new Vector2(mousePosition.x, mousePosition.y);
        }

        Vector2 direction = followSpot - rb.position;

        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        anim.SetBool("IsMoving", direction.magnitude > 0.1f);

        if (direction.x > 0.01f)
            spriteRenderer.flipX = false;
        else if (direction.x < -0.01f)
            spriteRenderer.flipX = true;
    }


    
    void FixedUpdate()
    {
        Debug.Log("followSpot: " + followSpot + " | position: " + transform.position);
        float distance = Vector2.Distance(rb.position, followSpot);
        float step = speed * Time.fixedDeltaTime;

        if (distance > step)
        {
            Vector2 direction = (followSpot - rb.position).normalized;
            rb.MovePosition(rb.position + direction * step);
        }
        else
        {
            rb.MovePosition(followSpot);
        }
    }

}

