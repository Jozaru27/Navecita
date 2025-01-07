using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{

    public float speed = 0.1f;
    public float maxSpeed = 0;
    public float minSpeed = 0;

    public float temporizadorAcelerar = 10;

    public Renderer motorDerecho;
    public Renderer motorIzquierdo;

    private Color colorOriginal;

    private bool acelerando = false;

    private void Awake()
    {
        colorOriginal = motorDerecho.material.color;
        maxSpeed = speed * 2;
        minSpeed = speed;
    }

    void FixedUpdate()
    {
        applyRotation();
        applyMovement();

    }

    private void applyMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed);
        } else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * speed);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed);
        } else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            acelerando = true;
            // cambiar la velocidad a que vaya el doble de rapido   speed * 3;
        }
    }

    private void applyRotation()
    {

        float sumarX = 0;
        float sumarY = 0;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            sumarY = 1;
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            sumarY = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            sumarX = 1;
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            sumarX = -1;
        }

        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x + sumarY,
            transform.eulerAngles.y + sumarX,
            transform.eulerAngles.z);
    }

}
