using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Gestor_Dialogos : MonoBehaviour
{


    public GameObject Dialogo1;
    public GameObject Dialogo2;
    public GameObject Dialogo3;

    public GameObject Alert1;
    public TMPro.TMP_Text TXT_Instruccion_Estado;

    void Start()
    {
        StartCoroutine(SecuenciaDialogo());
        Dialogo1.SetActive(true);
        Dialogo2.SetActive(false);
        Dialogo3.SetActive(false);

        Alert1.SetActive(false);
    }

    public IEnumerator SecuenciaDialogo()
    {
        Dialogo1.SetActive(true);
        yield return new WaitForSeconds(4f);

        Dialogo1.SetActive(false);
        Dialogo2.SetActive(true);
        yield return new WaitForSeconds(3f);

        Dialogo2.SetActive(false);
        Dialogo3.SetActive(true);
        yield return new WaitForSeconds(2f);

    }

    public void update(int Repeticiones, int Objetivo, string Instruccion)
    {
        //Tengo que usar un desagradable "ifElse" porque no puedo usar Switch con rangos.
        //Que desagradable.


        float progreso = (float)Repeticiones / Objetivo;

        if (progreso < 0.33f)
        {
            TXT_Instruccion_Estado.text = $"¡Muy bien! Ahora {Instruccion}";
        }
        else if (progreso < 0.66f)
        {
            TXT_Instruccion_Estado.text = $"Sigue así, {Instruccion}";
        }
        else if (Repeticiones < Objetivo)
        {
            TXT_Instruccion_Estado.text = $"¡Últimas repeticiones! {Instruccion}";
        }
        else
        {
            TXT_Instruccion_Estado.text = "¡Objetivo alcanzado!";
            Alert1.SetActive(true);
        }

    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Continuar()
    {
        Alert1.SetActive(false);
    }
}
