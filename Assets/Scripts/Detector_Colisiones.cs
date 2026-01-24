using UnityEngine;
using UnityEngine.SceneManagement;

public class Detector_Colisiones : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Objeto tocado");
    }
}
