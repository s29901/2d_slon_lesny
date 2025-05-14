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
        // Вычисляем направление движения
        Vector2 direction = (followSpot - (Vector2)transform.position).normalized;

        // Проверяем расстояние до цели
        float distance = Vector2.Distance(transform.position, followSpot);

        // Проверяем, не находимся ли мы уже в точке
        if (distance > 0.05f)
        {
            // Перемещаем игрока, используя физику
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }
}

