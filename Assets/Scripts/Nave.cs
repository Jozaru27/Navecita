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

    public AroManager aroManager;

    public UIManager uiManager; 

    public bool aroAtravesado = false; 

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

        // -- ACELERAR CON LSHIFT --

        // // CUANDO SE PULSE LA TECLA SHIFT (!!! No siempre detecta que se pulse o se suelte Left Shift)
        // if (Input.GetKeyDown(KeyCode.LeftShift))
        // {
        //     acelerando = true;  // Cambia el booleano de acelerando a activo
        //     speed = maxSpeed;  // Aumenta la velocidad a la velocidad máxima
        // }
        // // CUANDO SE SUELTE LA TECLA SHIFT
        // if (Input.GetKeyUp(KeyCode.LeftShift))
        // {
        //     acelerando = false; // Cambia el booleano de acelerando a desactivado
        //     speed = minSpeed;  // Disminuye la velocidad a la velocidad mínima (normal)
        // }

        // Si LShift está pulsado, aumenta la velocidad y cambia el booleano de acelerando a verdadero. Si no lo está, disminuye la velocidad y cambia el booleano a falso.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            acelerando = true;
            speed = maxSpeed;
        }
        else
        {
            acelerando = false;
            speed = minSpeed;
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

    void OnTriggerEnter(Collider other)
    {
        // Si el objeto con el que la nave colisiona tiene el tag "Aro" y no ha atravesado ese aro aún
        if (other.CompareTag("Aro"))
        {
            aroManager.AroPasado(other.gameObject);
        }

        // Si el objeto con el que la nave colisiona tiene el tag "Moneda"
        if (other.CompareTag("Moneda"))
        {
            // Destruye la moneda
            Destroy(other.gameObject);

            // Llama al UIManager para sumar una moneda
            uiManager.SumarMoneda();
        }
    }

    // Resetear el flag cuando ya no estamos tocando el aro
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Aro"))
        {
            aroAtravesado = false; 
        }
    }

}
