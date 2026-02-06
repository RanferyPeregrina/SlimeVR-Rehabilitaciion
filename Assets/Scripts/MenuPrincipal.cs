using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject UIPrincipal;
    public GameObject UISeleccion;


    public void Start()
    {
        UIPrincipal.SetActive(true);
        UISeleccion.SetActive(false);
    }

    public void IniciarJuego()
    {
        UIPrincipal.SetActive(false);
        UISeleccion.SetActive(true);
    }

    public void Regresar()
    {
        UIPrincipal.SetActive(true);
        UISeleccion.SetActive(false);
    }

    public void QuitarJuego()
    {
        Application.Quit();
    }


}
