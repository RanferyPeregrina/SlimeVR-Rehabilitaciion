using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitarJuego()
    {
        Application.Quit();
    }
}
