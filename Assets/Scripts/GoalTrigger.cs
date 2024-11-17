using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Meta alcanzada! Reiniciando escena...");

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
