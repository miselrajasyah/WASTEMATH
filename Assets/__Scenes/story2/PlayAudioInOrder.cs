using System.Collections;
using UnityEngine;

public class PlayAudioInOrder : MonoBehaviour
{
    public AudioSource[] audioSources; // Drag & drop AudioSource dari Hierarchy
    public float delayBeforePlay = 1f; // Delay sebelum memulai audio pertama (detik)
    public float delayAfterPlay = 1f; // Delay setelah audio selesai (detik)
    public float initialDelay = 5f; // Penundaan awal sebelum memulai audio sequence (detik)

    void Start()
    {
        StartCoroutine(PlayAudioSequence());
    }

    IEnumerator PlayAudioSequence()
    {
        // Penundaan awal sebelum mulai
        yield return new WaitForSeconds(initialDelay);

        // Memutar setiap AudioSource secara berurutan
        bool isFirstAudio = true; // Flag untuk audio pertama
        foreach (AudioSource audioSource in audioSources)
        {
            if (isFirstAudio)
            {
                // Delay sebelum memulai audio pertama
                yield return new WaitForSeconds(delayBeforePlay);
                isFirstAudio = false; // Set flag ke false setelah audio pertama diputar
            }

            audioSource.Play();

            // Tunggu sampai audio selesai diputar ditambah dengan delay setelah play
            yield return new WaitForSeconds(audioSource.clip.length + delayAfterPlay);
        }
    }
}
