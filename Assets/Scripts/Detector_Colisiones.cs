using UnityEngine;
using UnityEngine.SceneManagement;

public class Detector_Colisiones : MonoBehaviour
{
    private Animator animator;
    public Transform ParteCuerpo;

    public void Start()
    {
        animator = GetComponent<Animator>(); //Ubica el cuerpo
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.IsChildOf(GameObject.Find("Rehabi0-0").transform))
        {
            Debug.Log($"Colisión con: {collision.collider.name}");
            Debug.Log("Parte del cuerpo: " + collision.collider.name);
        }
    }

}
