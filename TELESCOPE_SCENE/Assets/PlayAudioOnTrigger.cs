using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioSource; // Assign your AudioSource in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Adjust this tag based on your player's tag
        {
            audioSource.Play();
        }
    }
}
