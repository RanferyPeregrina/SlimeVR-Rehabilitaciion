using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Lector_Sensores : MonoBehaviour
{
    [Header("Referencias de UI")]
    public TMP_Text Texto_Distancia;
    public TMP_Text Texto_Estado;
    public Image Cuadrito_Fondo;

    [Header("Configuración del Ejercicio")]
    [Tooltip("Distancia en metros para considerar que el brazo está cerca de la pierna")]
    public float umbralCerca = 0.45f; 

    private Animator animator;
    private Transform brazoDerecho; // Sensor arriba del codo (RightUpperArm)
    private Transform piernaDerecha; // Sensor en la pierna (RightLowerLeg)

    void Start() 
    {
        animator = GetComponent<Animator>();
        
        if (animator == null)
        {
            Debug.LogError("No se encontró el componente Animator en este objeto.");
            return;
        }

        // Buscamos los huesos correspondientes a la ubicación de tus sensores SlimeVR
        brazoDerecho = animator.GetBoneTransform(HumanBodyBones.RightUpperArm); 
        piernaDerecha = animator.GetBoneTransform(HumanBodyBones.RightLowerLeg); 

        if (brazoDerecho == null || piernaDerecha == null)
        {
            Debug.LogError("Error: No se pudieron encontrar los huesos. Revisa que el avatar sea 'Humanoid'.");
        }
    }

    void Update() 
    {
        if (brazoDerecho == null || piernaDerecha == null) return;

        // Calculamos la distancia real en el espacio 3D
        float distanciaActual = Vector3.Distance(brazoDerecho.position, piernaDerecha.position);
        
        // Dibujamos una línea en la ventana de Scene para depuración
        Debug.DrawLine(brazoDerecho.position, piernaDerecha.position, Color.yellow);

        // Actualizamos el texto en pantalla
        if (Texto_Distancia != null)
        {
            Texto_Distancia.text = "Distancia: " + distanciaActual.ToString("F2") + " m";
        }

        // Lógica de detección según el umbral
        if (distanciaActual <= umbralCerca)
        {
            Texto_Estado.text = "ESTADO: ABAJO";
            if (Cuadrito_Fondo != null) Cuadrito_Fondo.color = Color.green;
        }
        else
        {
            Texto_Estado.text = "ESTADO: ARRIBA";
            if (Cuadrito_Fondo != null) Cuadrito_Fondo.color = Color.white;
        }
    }
}