using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public enum ControlScheme { WASD, Arrows }

    [Header("Controles")]
    public ControlScheme controls = ControlScheme.WASD;

    [Header("Movimiento")]
    public float speed = 5f;
    public float rotationStep = 10f;

    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PlayerMovement();
        Rotation();
        NewColor();
    }

    void PlayerMovement()
    {
        Vector2 dir = Vector2.zero;

        if (controls == ControlScheme.WASD)
        {
			if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 1f * speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-1f * speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, -1f * speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(1f * speed * Time.deltaTime, 0, 0);
            }
        }
        else // Flechas
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, 1f * speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-1f * speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, -1f * speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(1f * speed * Time.deltaTime, 0, 0);
            }
        }

        // Movimiento fijo
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }

    void Rotation()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0, 0, rotationStep);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0, 0, -rotationStep);
        }
    }

    void NewColor()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            sr.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}