using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject monedaPrefab;  // Prefab de la moneda
    public List<Transform> puntosSpawn = new List<Transform>();  // Lista que recoge los 50 Puntos de spawn de monedas

    public UIManager uiManager; // Para el Manager del Canva
    public AroManager aroManager; // Para el Manager de los Aros

    void Start()
    {
        SpawnMonedas();
        uiManager.totalAros = aroManager.aros.Count;  
    }

    void Update()
    {
        
    }

    // Método Principal para Spawnear Monedas en la Escena
    void SpawnMonedas()
    {
        // Dividir los puntos de Spawn en Segmentos
        List<Transform> puntosPrimerSegmento = puntosSpawn.GetRange(0, 25);  // Primeros 25 puntos (5 primeros aros)
        List<Transform> puntosSegundoSegmento = puntosSpawn.GetRange(25, 15); // Siguientes 15 puntos (3 siguientes aros)
        List<Transform> puntosTercerSegmento = puntosSpawn.GetRange(40, 10);  // Últimos 10 puntos (2 últimos aros)

        // Generar monedas, pasándole a la función a la que llama el segmento y la cantidad de monedas.
        SpawnMonedasEnSegmento(puntosPrimerSegmento, 15);  // 15 monedas en primeros 5 aros (primer segmento)
        SpawnMonedasEnSegmento(puntosSegundoSegmento, 5);  // 5 monedas en los siguientes 3 aros (segundo Segmento)
    }


    // Método Auxiliar para Spawnear Monedas en Puntos Aleatorios dentro de Segmentos
    void SpawnMonedasEnSegmento(List<Transform> puntos, int cantidad)
    {
        // HashSet almacena los índices utilizados - Evita instanciar más de una moneda en el mismo punto
        HashSet<int> indicesUsados = new HashSet<int>();

        // Mientras que no se hayan colocado la cantidad deseada de monedas.
        while (indicesUsados.Count < cantidad)
        {
            // Selecciona un índice aleatorio dentro del rango de puntos disponibles
            int indiceAleatorio = Random.Range(0, puntos.Count);

            // En caso de que el índice seleccionado no haya sido seleccionado anteriormente, crea el prefab de la moneda y lo añade al HashSet.
            if (!indicesUsados.Contains(indiceAleatorio))
            {
                Instantiate(monedaPrefab, puntos[indiceAleatorio].position, Quaternion.identity);
                indicesUsados.Add(indiceAleatorio);
            }
        }
    }
}