using UnityEngine;

public class PlaneColliderDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto entrou em contato com o plano: " + other.name);

        // Para destacar o objeto visualmente
        Renderer rend = other.GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = Color.green; // muda a cor do objeto para verde
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Objeto saiu do plano: " + other.name);

        // Restaurar cor se quiser
        Renderer rend = other.GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = Color.white;
        }
    }
}
