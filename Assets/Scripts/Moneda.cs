using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public float alturaBalanceo = 0.5f;  // Altura máxima del balanceo
    public float velocidadBalanceo = 2f;  // Velocidad del balanceo
    public float velocidadRotacionBase = 50f;  // Velocidad mínima de rotación
    public float distanciaMaxima = 10f;  // Distancia máxima donde empieza a aumentar la rotación

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        AplicarBalanceo();
        AplicarRotacion();
    }

    void AplicarBalanceo()
    {
        // Movimiento de balanceo en el eje Y usando Seno para crear un movimiento suave
        float nuevoY = posicionInicial.y + Mathf.Sin(Time.time * velocidadBalanceo) * alturaBalanceo;
        transform.position = new Vector3(transform.position.x, nuevoY, transform.position.z);
    }

    void AplicarRotacion()
    {
        // Obtener la distancia entre la nave (jugador) y la moneda
        GameObject nave = GameObject.FindWithTag("Player");

        if (nave != null)
        {
            float distancia = Vector3.Distance(transform.position, nave.transform.position);
            float velocidadRotacion = velocidadRotacionBase;

            // Aumentar la velocidad de rotación si el jugador se acerca
            if (distancia < distanciaMaxima)
            {
                velocidadRotacion += (distanciaMaxima - distancia) * 10f;  // Aumentar la rotación cuanto más cerca esté
            }

            // Aplicar rotación
            transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
        }
    }
}
