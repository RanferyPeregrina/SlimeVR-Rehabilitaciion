using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI tiempoTexto;
    private float tiempo;

    void Update()
    {
        tiempo += Time.deltaTime;

        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);

        tiempoTexto.text = $"Tiempo: {minutos:00}:{segundos:00}";
    }
}