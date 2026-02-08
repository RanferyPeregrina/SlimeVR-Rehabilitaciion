//Este script es para medir e imprimir en el Canvas la distancia entre 2 partes del cuerpo.
//Este script va pegado al VRM al que le queremos medir las distancias.

using UnityEngine;
using UnityEngine.UI;


public class DetectorRepeticiones_Rodilla : MonoBehaviour
{
    public Gestor_Dialogos GestorDialogos;
    
    public TMPro.TMP_Text TXT_Repeticiones;
    public TMPro.TMP_Text TXT_Objetivo;
    public TMPro.TMP_Text TXT_Instruccion_Estado;

    private Animator animator;
    private Transform Pecho;
    private Transform RodillaDerecha;

    string EstadoActual, EstadoPasado, Instruccion;
    int Repeticiones = 0;
    int Objetivo = 10;


    public void Start() 
        // Validaciones iniciales de componentes - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    {
        animator = GetComponent<Animator>();                                //Ubica el cuerpo
        Pecho = animator.GetBoneTransform(HumanBodyBones.Chest);   //Ubica el pecho
        RodillaDerecha = animator.GetBoneTransform(HumanBodyBones.RightLowerLeg); //Ubica la rodilla

        // Si no los encuentra, avisa.
        if (Pecho == null || RodillaDerecha == null){Debug.LogError("No se encontraron los huesos necesarios");}

    }

    public void Update() //------------------------ Esta funcion va midiendo e imprimiendo
    {
        if (Pecho == null || RodillaDerecha == null) return; // Si no los encuentra, no hace na'
        float distanciaActual = Vector3.Distance(Pecho.position, RodillaDerecha.position);
        print("La distancia entre la mano derecha y la rodilla derecha es: " + distanciaActual);

        // Todo esto es la maquinita de estados.
        if (distanciaActual <= 0.460)
        {
            EstadoActual = "Arriba";
            Instruccion = "Abajo";
        } else if (distanciaActual >= 0.600)            
        {                                               
            EstadoActual = "Abajo";
            Instruccion = "Arriba";
            if (EstadoPasado == "Arriba") { Repeticiones++; }  
        }
        EstadoPasado = EstadoActual;

        TXT_Objetivo.text = Objetivo.ToString();                  
        TXT_Repeticiones.text = Repeticiones.ToString();

        GestorDialogos.update(Repeticiones, Objetivo, Instruccion); // Le avisa al gestor de dialogos que cambie el texto de la instruccion

    }

    public void ContinuarEjercicio()
    {
        Repeticiones = 0;
        Objetivo += Objetivo; // duplica

        Debug.Log("Ejercicio reiniciado. Nuevo objetivo: " + Objetivo);
    }



}

