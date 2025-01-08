using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public float alturaBalanceo = 0.5f;   // Cuánto sube y baja la moneda
    public float velocidadBalanceo = 2f;  
    public float velocidadRotacion = 100f; 
    public float distanciaMaxima = 35f;   // Distancia donde la rotación empieza a aumentar

    private Vector3 posicionInicial;    // Posición de la Moneda
    private Transform nave;         // Prefab de la nave


    void Start()
    {
        posicionInicial = transform.position; // Guarda la posición de la Moneda
        nave = GameObject.FindWithTag("Nave").transform; // Busca el GameObject con el Tag Nave

        // CÓDIGO ADICIONAL PARA ORGANIZAR LOS GAME OBJECTS
        // Agrupar monedas bajo ==OBJETOS MONEDAS==

        // Busca el Game Object Vacío Padre
        Transform contenedor = GameObject.Find("==OBJETOS MONEDAS==")?.transform;

        // Hace que la moneda sea hija del Game Object Padre
        transform.parent = contenedor;

        // Renombra la moneda automáticamente
        int numMonedas = contenedor.childCount;
        gameObject.name = "Moneda " + numMonedas;
    }


    void Update()
    {
        // Balanceo suave en el eje Y (de arriba a abajo)
        float nuevoY = posicionInicial.y + Mathf.Sin(Time.time * velocidadBalanceo) * alturaBalanceo;
        transform.position = new Vector3(transform.position.x, nuevoY, transform.position.z);

        // Si la distancia entre la NAVE y la MONEDA disminuyen, acelera la velocidad de rotación
        float distancia = Vector3.Distance(transform.position, nave.position);
        float rotacionActual = velocidadRotacion;

        if (distancia < distanciaMaxima)
        {
            rotacionActual += (distanciaMaxima - distancia) * 35f;
        }

        // Rotar sobre el eje Z
        transform.Rotate(Vector3.up * rotacionActual * Time.deltaTime);
    }
}
