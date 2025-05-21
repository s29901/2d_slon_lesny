using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Vector2 followSpot;
    public float speed = 5f;
    public float persectiveScale;
    
    private Rigidbody2D rb;

    void Start()
    {
       followSpot = transform.position;
        rb = GetComponent<Rigidbody2D>();
       //followSpot = PlayerMemory.HasSavedPosition ? PlayerMemory.LastPosition : transform.position;

       
    }

    
    void Update()
    {
        // Получаем позицию мыши в мире
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // Если нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            followSpot = new Vector2(mousePosition.x, mousePosition.y);
        }
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

