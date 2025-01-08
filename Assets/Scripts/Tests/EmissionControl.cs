using UnityEngine;

public class EmissionControl : MonoBehaviour
{
    public float emissionIntensity = 1.5f; // Intensidad del brillo
    public Color emissionColor = Color.white; // Color del brillo
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.EnableKeyword("_EMISSION");
            UpdateEmission();
        }
    }

    void UpdateEmission()
    {
        if (rend != null)
        {
            Color finalColor = emissionColor * Mathf.LinearToGammaSpace(emissionIntensity);
            rend.material.SetColor("_EmissionColor", finalColor);
        }
    }

    public void SetEmissionIntensity(float intensity)
    {
        emissionIntensity = intensity;
        UpdateEmission();
    }

    public void SetEmissionColor(Color color)
    {
        emissionColor = color;
        UpdateEmission();
    }
}
