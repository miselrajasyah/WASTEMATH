using System.Collections;
using UnityEngine;

public class AudioDelay : MonoBehaviour
{
    public AudioSource audioSource; // Referensi ke AudioSource
    public float delay = 1.0f; // Waktu jeda sebelum audio dimainkan

    private void Start()
    {
        if (audioSource != null)
        {
            StartCoroutine(PlayAudioWithDelay());
        }
        else
        {
            Debug.LogError("AudioSource belum diatur di Inspector!");
        }
    }

    private IEnumerator PlayAudioWithDelay()
    {
        yield return new WaitForSeconds(delay); // Tunggu sesuai waktu delay
        audioSource.Play(); // Putar audio
    }
}
