using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private Sprite liquidSpr;
    [SerializeField] private Sprite solidSpr;
    [SerializeField] private Sprite gasSpr;
    [SerializeField] private GameObject text;
    [SerializeField] private Transform playerPos;
    [SerializeField] private Rigidbody2D rb;
    public float MoveSpeed;

    private Vector2 movement;
    public Substance Substance;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.color = Substance.Color;
        switch (Substance.AggrState)
        {
            case "Liquid":
                spr.sprite = liquidSpr;
                break;
            case "Solid":
                spr.sprite = solidSpr;
                break;
            case "Gas":
                spr.sprite = gasSpr;
                break;
        }

        text = transform.GetChild(0).gameObject;
        text.GetComponent<TextMesh>().text = Substance.Formula;

        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (playerPos.position.x > transform.position.x)
            movement.x++;
        if (playerPos.position.x < transform.position.x)
            movement.x--;
        if (playerPos.position.y > transform.position.y)
            movement.y++;
        if (playerPos.position.y < transform.position.y)
            movement.y--;

        rb.MovePosition(rb.position + movement * MoveSpeed * Time.deltaTime);
        movement = new Vector2(0, 0);
    }
}
