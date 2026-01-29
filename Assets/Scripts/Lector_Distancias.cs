//Este script es para medir e imprimir en el Canvas la distancia entre 2 partes del cuerpo.
//Este script va pegado al VRM al que le queremos medir las distancias.

using UnityEngine;
using UnityEngine.UI;


public class Lector_Distancias : MonoBehaviour
{
    public enum EstadoRodilla {ReposoAbajo, Subiendo, Arriba, Bajando}
    public TMPro.TMP_Text Texto_Distancia;
    public TMPro.TMP_Text Texto_Estado;
    private Animator animator;
    private Transform pecho;
    private Transform rodillaIzquierda;
    public Image Cuadrito_Fondo;
    string estadoActual;
    string estadoPasado;
    int Puntos = 0;



    public void Start() 
    {
        animator = GetComponent<Animator>();                                //Ubica el cuerpo
        pecho = animator.GetBoneTransform(HumanBodyBones.Chest);            //Ubica el pecho
        rodillaIzquierda = animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg); //Ubica el muslo
        // Si no los encuentra, avisa.
        if (pecho == null || rodillaIzquierda == null){Debug.LogError("No se encontraron los huesos necesarios");}
    }

    public void Update() 
    {
        // Validaciones iniciales de componentes - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        if (pecho == null || rodillaIzquierda == null) return; // Si no los encuentra, no hace na'
        Debug.DrawLine(pecho.position, rodillaIzquierda.position, Color.red);


        // Asume posiciones y velocidades de las cosas - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        float distanciaActual = Vector3.Distance(pecho.position, rodillaIzquierda.position);
        //Debug.Log($"Distancia muslo-pecho: {distanciaActual:F3}");    //Imprime la distancia en la consola.
        Texto_Distancia.text = distanciaActual.ToString();            //Imprime la distancia en el texto que identificamos al principio


        // Máquina de estados - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        if (distanciaActual <= 0.490){      // Si pasa esa distancia (Se acerca al pecho)
            estadoActual = "Arriba";        // Está arriba
        }
        else if (distanciaActual >= 0.623){ // Si pasa esa distancia (Lejos del pecho)
            estadoActual = "Abajo";         // Está abajo
            if (estadoPasado == "Arriba"){
                Puntos += 1;    //Y solo si la bajas después de haberla subido, se te suma un punto.
            }
        }
        estadoPasado = estadoActual;


            // Esto es de la UI de Debug- - - - - - - - - - - - - - - - - - - - - - - - - - - -- - - -- - - -- - - -- - - -- - - -- - -
            Texto_Distancia.text = distanciaActual.ToString("F3");
        Texto_Estado.text = estadoActual;
        Debug.Log($"Puntuación: {Puntos}");

    }

    
}

