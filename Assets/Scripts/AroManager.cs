using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroManager : MonoBehaviour
{
    public List<GameObject> aros;  // Lista de todos los aros en orden
    public int aroActual = 0;  // Índice del aro que debe ser atravesado

    private Color colorOriginal = Color.black;
    private Color colorAroPasado = Color.red;
    private Color colorAroActual = Color.green;

    public UIManager uiManager; // Referencia al UIManager

    void Start()
    {
        uiManager.totalAros = aros.Count;

        // Establece todos los aros al color negro inicialmente
        foreach (GameObject aro in aros)
        {
            aro.GetComponent<Renderer>().material.color = colorOriginal;
        }

        // Muestra el aro inicial como verde
        if (aros.Count > 0)
        {
            aros[aroActual].GetComponent<Renderer>().material.color = colorAroActual;
        }
    }

    // Este método se llama cuando la nave pasa por un aro
    public void AroPasado(GameObject aro)
    {
        if (aros[aroActual] == aro)
        {
            // Cambia el color del aro pasado a rojo
            aros[aroActual].GetComponent<Renderer>().material.color = colorAroPasado;


            // Recoge todos los colliders que tenga el Aro
            Collider[] colliders = aros[aroActual].GetComponents<Collider>();

            // Desactiva todos los Colliders en el objeto
            foreach (Collider col in colliders)
            {
                col.enabled = false;  
            }


            // Si no es el último aro, pasa al siguiente
            if (aroActual < aros.Count - 1)
            {
                aroActual++;

                // Cambia el color del siguiente aro a verde
                aros[aroActual].GetComponent<Renderer>().material.color = colorAroActual;

                // Actualiza el contador de aros en el UI
                uiManager.RestarAro();
            }
            else
            {
                // Si es el último aro, actualiza el UI y termina
                uiManager.RestarAro();
                uiManager.MostrarYouWin();
            }
        }
    }
}
