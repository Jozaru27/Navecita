using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textoMonedas;
    public TextMeshProUGUI textoAros;
    public TextMeshProUGUI textoTemporizador;

    public int totalAros = 0;
    public float tiempoRestante = 60f;
    private int monedasRecolectadas = 0;
 
    public GameObject panelFinal;  
    public GameObject imagenYouWin;  
    public GameObject imagenYouLose; 

    public TextMeshProUGUI textoPuntuacionFinal;
    public TextMeshProUGUI textoTiempoFinal;
    public TextMeshProUGUI textoMonedasFinal;
    public TextMeshProUGUI textoArosFinal;

    public Button botonVolverAJugar;

    void Start()
    {
        Time.timeScale = 1;
        panelFinal.SetActive(false);
        ActualizarUI();

        botonVolverAJugar.onClick.AddListener(VolverAJugar); 
    }


    void Update()
    {
        // Mientras que quede tiempo, irá actualizando el temporizador. Si el tiempo se agota, lo mostará en texto.
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            ActualizarUI();
        }
        else
        {
            tiempoRestante = 0;
            textoTemporizador.text = "¡Tiempo Agotado!";
            MostrarGameOver(); 
        }

        // Cambia el color del temporizador a rojo cuando quedan 10 segundos.
        if (tiempoRestante < 10)
        {
            textoTemporizador.color = Color.red;
        }
    }


    // Función para sumar moneda cada vez que recoges una.
    public void SumarMoneda()
    {
        monedasRecolectadas++;
        ActualizarUI();
    }


    // Función para sumar aros cada vez que lo cruces.
    public void RestarAro()
    {
        if (totalAros > 0)
        {
            totalAros--;
            ActualizarUI();
        }
    }

    // Función para actualizar el texto del Canvas
    void ActualizarUI()
    {
        textoMonedas.text = "x " + monedasRecolectadas;
        textoAros.text = "x " + totalAros;
        textoTemporizador.text = "Tiempo: " + Mathf.CeilToInt(tiempoRestante);
    }


    // Función para mostrar el panel de YouWin
    public void MostrarYouWin()
    {
        // Calcular puntuación
        int puntuacion = Mathf.CeilToInt(tiempoRestante) + (monedasRecolectadas * 2);
        textoPuntuacionFinal.text = "Puntuación: " + puntuacion;

        // Muestra detalles
        textoMonedasFinal.text = "Monedas: " + monedasRecolectadas;
        textoArosFinal.text = "Aros Restantes: " + (totalAros);  // Total de aros recogidos
        textoTiempoFinal.text = "Tiempo Restante: " + Mathf.CeilToInt(tiempoRestante);

        // Muestra la imagen de victoria y ocultar la de derrota
        imagenYouWin.SetActive(true);
        imagenYouLose.SetActive(false);
        panelFinal.SetActive(true);  // Muestra el panel final

        Time.timeScale = 0;
    }


    // Función para mostrar el panel de Game Over
    public void MostrarGameOver()
    {
        // Muestra detalles de la derrota
        textoPuntuacionFinal.text = "Puntuación: " + (monedasRecolectadas * 2);
        textoMonedasFinal.text = "Monedas: " + monedasRecolectadas;
        textoArosFinal.text = "Aros Restantes: " + (totalAros);  // Total de aros recogidos
        textoTiempoFinal.text = "Tiempo: 0";  // El tiempo es 0 en este caso.

        // Muestra la imagen de derrota y ocultar la de victoria
        imagenYouWin.SetActive(false);
        imagenYouLose.SetActive(true);
        panelFinal.SetActive(true);  // Muestra el panel final

        Time.timeScale = 0;
    }


    // Función para reiniciar el juego
    public void VolverAJugar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}