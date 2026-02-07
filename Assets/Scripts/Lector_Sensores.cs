//Este script es para medir e imprimir en el Canvas la distancia entre 2 partes del cuerpo.
//Este script va pegado al VRM al que le queremos medir las distancias.

using UnityEngine;
using UnityEngine.UI;


public class Lector_Sensores : MonoBehaviour
{
    public TMPro.TMP_Text Texto_Distancia1;
    public TMPro.TMP_Text Texto_Estado1;
    private Animator CuerpoMono;
    private Transform pierna_derecha;
    private Transform mano_derecha;
    public Image Cuadrito_Fondo;
    string EstadoActual1, EstadoPasado1;
    int Repeticiones1 = 0;


    public void Start()
    // Validaciones iniciales de componentes - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    {
        CuerpoMono = GetComponent<Animator>();                                //Ubica el cuerpo
        pierna_derecha = CuerpoMono.GetBoneTransform(HumanBodyBones.RightLowerLeg);            //Ubica pierna derecha
        mano_derecha = CuerpoMono.GetBoneTransform(HumanBodyBones.RightLowerArm); //Ubica la mano derecha

        // Si no los encuentra, avisa.
        if (pierna_derecha == null || mano_derecha == null) { Debug.LogError("No se encontraron los huesos necesarios"); }
    }

    public void Update() //------------------------ Esta funcion va midiendo e imprimiendo
    {
        if (pierna_derecha == null || mano_derecha == null) return; // Si no los encuentra, no hace na'
        float distanciaActual1 = Vector3.Distance(pierna_derecha.position, mano_derecha.position);


        // Todo esto es la maquinita de estados.
        if (distanciaActual1 >= 0.90)                   //Si la distancia pierna-brazo es larga
        {                                               //entonces subió
            EstadoActual1 = "Arriba";
        }
        else if (distanciaActual1 <= 0.65)            //Si la distnacia pierna-brazo es corta
        {                                               //entonces bajó
            EstadoActual1 = "Abajo";
            if (EstadoPasado1 == "Arriba") { Repeticiones1++; }  //Si repetiste ese movimiento, cuenta una repetición.
        }
        EstadoPasado1 = EstadoActual1;

        Debug.DrawLine(pierna_derecha.position, mano_derecha.position, Color.red);
        Texto_Distancia1.text = distanciaActual1.ToString();            //Imprime la distancia.
        Texto_Estado1.text = EstadoActual1.ToString();                  //Imprime las reperticiones.
        Debug.Log($"Las repeticiones hasta ahora son: {Repeticiones1}");
    }




}

