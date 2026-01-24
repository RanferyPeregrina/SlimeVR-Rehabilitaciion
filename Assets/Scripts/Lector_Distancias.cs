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


    public void Start() //----------------------- Esta función inicializa todo
    {
        animator = GetComponent<Animator>(); //Ubica el cuerpo

        chest = animator.GetBoneTransform(HumanBodyBones.Chest);            //Ubica el pecho
        leftThigh = animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg); //Ubica el muslo

        if (chest == null || leftThigh == null)     // Si no los encuentra, avisa.
        {
            Debug.LogError("No se encontraron los huesos necesarios");
        }
    }

    public void Update() //------------------------ Esta función va midiendo e imprimiendo
    {

        if (chest == null || leftThigh == null) return; // Si no los encuentra, no hace na'


        float Distancia = Vector3.Distance(chest.position, leftThigh.position);
        Debug.Log($"Distancia muslo-pecho: {Distancia:F3}");    //Imprime la distancia en la consola.
        Texto_Distancia.text = Distancia.ToString();            //Imprime la distancia en el texto que identificamos al principio
                                                                //En el mundo lo asigné a "TXT_Distancia"


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

