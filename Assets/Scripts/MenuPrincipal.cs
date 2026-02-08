using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject UIPrincipal;
    public GameObject UISeleccion;

    // Menú principal
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

    public void QuitarJuego()
    {
        Application.Quit();
    }


    // Selección de ejercicios
    public void Regresar()
    {
        UIPrincipal.SetActive(true);
        UISeleccion.SetActive(false);
    }

    public void CargarRodilla1()
    {
        SceneManager.LoadScene("EjerciciosRodillas");
    }
    public void CargarHombros1()
    {
        SceneManager.LoadScene("EjerciciosHombros");
    }



}
