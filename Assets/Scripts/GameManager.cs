using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject monedaPrefab;  // Prefab de la moneda
    public List<Transform> puntosSpawn = new List<Transform>();  // Lista que recoge los 50 Puntos de spawn de monedas

    void Start()
    {
        SpawnMonedas(); // Llama a la función de Spawnear monedas
    }

    void Update()
    {
        
    }

    // Hace aparecer prefabs de Moneda
    void SpawnMonedas()
    {
        // Dividir los puntos de Spawn en Segmentos
        List<Transform> puntosPrimerSegmento = puntosSpawn.GetRange(0, 25);  // Primeros 25 puntos (5 primeros aros)
        List<Transform> puntosSegundoSegmento = puntosSpawn.GetRange(25, 15); // Siguientes 15 puntos (3 siguientes aros)
        List<Transform> puntosTercerSegmento = puntosSpawn.GetRange(40, 10);  // Últimos 10 puntos (2 últimos aros)

        // Spawnear monedas según las reglas establecidas en la práctica
        SpawnMonedasEnSegmento(puntosPrimerSegmento, 15);  // 15 monedas en primeros 5 aros (primer segmento)
        SpawnMonedasEnSegmento(puntosSegundoSegmento, 5);  // 5 monedas en los siguientes 3 aros (segundo Segmento)
        // No se spawnean monedas en los últimos 2 aros
    }

    // Spawnea x monedas en cada segmento
    void SpawnMonedasEnSegmento(List<Transform> puntos, int cantidad)
    {
        HashSet<int> indicesUsados = new HashSet<int>();

        while (indicesUsados.Count < cantidad)
        {
            int indiceAleatorio = Random.Range(0, puntos.Count);

            if (!indicesUsados.Contains(indiceAleatorio))
            {
                Instantiate(monedaPrefab, puntos[indiceAleatorio].position, Quaternion.identity);
                indicesUsados.Add(indiceAleatorio);
            }
        }
    }

    // void SpawnMonedasEnSegmento(List<Transform> puntos, int cantidad)
    // {
    //     List<Transform> copiaPuntos = new List<Transform>(puntos); // Copia de la lista original

    //     for (int i = 0; i < cantidad; i++)
    //     {
    //         if (copiaPuntos.Count == 0)
    //             break;

    //         int indiceAleatorio = Random.Range(0, copiaPuntos.Count);
    //         Instantiate(monedaPrefab, copiaPuntos[indiceAleatorio].position, Quaternion.identity);
    //         copiaPuntos.RemoveAt(indiceAleatorio);  // Elimina el punto usado
    //     }
    // }

}
