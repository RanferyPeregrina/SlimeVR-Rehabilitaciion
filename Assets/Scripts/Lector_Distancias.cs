//Este script es para medir e imprimir en el Canvas la distancia entre 2 partes del cuerpo.
//Este script va pegado al VRM al que le queremos medir las distancias.

using UnityEngine;
using UnityEngine.UI;


public class Lector_Distancias : MonoBehaviour
{
    public TMPro.TMP_Text Texto_Distancia;
    public TMPro.TMP_Text Texto_Estado;
    private Animator animator;
    private Transform chest;
    private Transform leftThigh;
    public Image Cuadrito_Fondo;


<<<<<<< Updated upstream
    public void Start() //----------------------- Esta función inicializa todo
    {
        animator = GetComponent<Animator>(); //Ubica el cuerpo

        chest = animator.GetBoneTransform(HumanBodyBones.Chest);            //Ubica el pecho
        leftThigh = animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg); //Ubica el muslo

        if (chest == null || leftThigh == null)     // Si no los encuentra, avisa.
        {
            Debug.LogError("No se encontraron los huesos necesarios");
        }
=======

    public void Start() 
        // Validaciones iniciales de componentes - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    {
        animator = GetComponent<Animator>();                                //Ubica el cuerpo
        pecho = animator.GetBoneTransform(HumanBodyBones.Chest);            //Ubica el pecho
        rodillaIzquierda = animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg); //Ubica el muslo
        
        // Si no los encuentra, avisa.
        if (pecho == null || rodillaIzquierda == null){Debug.LogError("No se encontraron los huesos necesarios");}
>>>>>>> Stashed changes
    }

    public void Update() //------------------------ Esta función va midiendo e imprimiendo
    {
<<<<<<< Updated upstream

        if (chest == null || leftThigh == null) return; // Si no los encuentra, no hace na'


        float Distancia = Vector3.Distance(chest.position, leftThigh.position);
        Debug.Log($"Distancia muslo-pecho: {Distancia:F3}");    //Imprime la distancia en la consola.
        Texto_Distancia.text = Distancia.ToString();            //Imprime la distancia en el texto que identificamos al principio
                                                                //En el mundo lo asigné a "TXT_Distancia"
=======
        if (pecho == null || rodillaIzquierda == null) return; // Si no los encuentra, no hace na'
        Debug.DrawLine(pecho.position, rodillaIzquierda.position, Color.red);


        // Asume posiciones y velocidades de las cosas - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        float distanciaActual = Vector3.Distance(pecho.position, rodillaIzquierda.position);
        //Debug.Log($"Distancia muslo-pecho: {distanciaActual:F3}");  
        Texto_Distancia.text = distanciaActual.ToString();            //Imprime la distancia en el texto que identificamos al principio
>>>>>>> Stashed changes


        if (Distancia <= 0.247)
        {
            Texto_Estado.text = "Abajo";
        }
        else
        {
            if(Distancia >= 0.247)
            {
                Texto_Estado.text = "Arriba";
            }
        }

    }

    
}

