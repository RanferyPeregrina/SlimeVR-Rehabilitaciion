//Este script es para medir e imprimir en el Canvas la distancia entre 2 partes del cuerpo.
//Este script va pegado al VRM al que le queremos medir las distancias.

using UnityEngine;
using UnityEngine.UI;


public class Lector_Distancias : MonoBehaviour
{
    public TMPro.TMP_Text Texto_Distancia;
    public TMPro.TMP_Text Texto_Estado;
    private Animator animator;
    private Transform pecho;
    private Transform rodillaIzquierda;
    public Image Cuadrito_Fondo;
    string EstadoActual, EstadoPasado;
    int Repeticiones = 0;


    public void Start() 
        // Validaciones iniciales de componentes - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    {
        animator = GetComponent<Animator>();                                //Ubica el cuerpo
        pecho = animator.GetBoneTransform(HumanBodyBones.Chest);            //Ubica el pecho
        rodillaIzquierda = animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg); //Ubica la rodilla
        
        // Si no los encuentra, avisa.
        if (pecho == null || rodillaIzquierda == null){Debug.LogError("No se encontraron los huesos necesarios");}
    }

    public void Update() //------------------------ Esta funcion va midiendo e imprimiendo
    {
        if (pecho == null || rodillaIzquierda == null) return; // Si no los encuentra, no hace na'
        float distanciaActual = Vector3.Distance(pecho.position, rodillaIzquierda.position);


        // Todo esto es la maquinita de estados.
        if (distanciaActual <= 0.490)                   //Si la distancia pierna-pecho es corta
        {                                               //entonces subió
            EstadoActual = "Arriba";
        } else if (distanciaActual >= 0.610)            //Si la distnacia pierna-pecho es larga
        {                                               //entonces bajó
            EstadoActual = "Abajo";
            if(EstadoPasado == "Arriba") { Repeticiones++; }  //Si repetiste ese movimiento, cuenta una repetición.
        }
        EstadoPasado = EstadoActual;

        Debug.DrawLine(pecho.position, rodillaIzquierda.position, Color.red);
        Texto_Distancia.text = distanciaActual.ToString();            //Imprime la distancia.
        Texto_Estado.text = EstadoActual.ToString();                  //Imprime las reperticiones.
        Debug.Log($"Las repeticiones hasta ahora son: {Repeticiones}");
    }



    
}

