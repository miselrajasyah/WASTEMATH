using UnityEngine;
using System.Collections;

public class imagedisplay : MonoBehaviour
{
    public GameObject[] images;       // Array gambar yang akan ditampilkan
    public float[] durations;         // Durasi setiap gambar ditampilkan
    public float[] delays;            // Jeda antar gambar
    public float initialDelay = 5f;   // Delay awal sebelum gambar pertama ditampilkan

    void Start()
    {
        // Pastikan jumlah gambar, durasi, dan jeda cocok
        if (images.Length != durations.Length || images.Length != delays.Length)
        {
            Debug.LogError("Jumlah gambar, durasi, dan jeda tidak cocok!");
            return;
        }

        // Memulai coroutine untuk menampilkan gambar
        StartCoroutine(DisplayImages());
    }

    // Coroutine untuk menampilkan gambar secara berurutan
    private IEnumerator DisplayImages()
    {
        // Sembunyikan semua gambar di awal
        foreach (GameObject image in images)
        {
            image.SetActive(false);
        }

        // Delay awal sebelum gambar pertama
        yield return new WaitForSeconds(initialDelay);

        // Menampilkan gambar secara berurutan
        for (int i = 0; i < images.Length; i++)
        {
            // Tampilkan gambar saat ini
            images[i].SetActive(true);
            Debug.Log($"Gambar {i + 1} diaktifkan.");

            // Tunggu selama durasi yang telah ditentukan
            yield return new WaitForSeconds(durations[i]);

            // Sembunyikan gambar saat ini
            images[i].SetActive(false);
            Debug.Log($"Gambar {i + 1} disembunyikan.");

            // Tunggu sebelum menampilkan gambar berikutnya
            if (i < delays.Length) // Pastikan tidak melebihi array
            {
                yield return new WaitForSeconds(delays[i]);
            }
        }
    }
}