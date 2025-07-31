using UnityEngine;
using System.Collections;

public class HideImage : MonoBehaviour
{
    public GameObject image;  // GameObject yang berisi gambar
    public float waitTime = 10f;  // Waktu tunggu sebelum gambar menghilang
    public float duration = 1f;  // Durasi animasi menghilang

    private Vector3 targetScale;
    private Vector3 initialScale;

    void Start()
    {
        // Pastikan gambar aktif saat mulai
        image.SetActive(true);

        // Memulai coroutine untuk menunggu 10 detik, kemudian menghilangkan gambar
        StartCoroutine(HideImageAfterTime());
    }

    private IEnumerator HideImageAfterTime()
    {
        // Tunggu selama 10 detik
        yield return new WaitForSeconds(waitTime);

        // Menyimpan skala awal objek (gambar)
        initialScale = image.transform.localScale;
        targetScale = Vector3.zero;  // Skala 0 untuk membuat gambar menghilang

        // Secara bertahap mengubah skala objek dari skala saat ini menjadi 0 (menghilang)
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            image.transform.localScale = Vector3.Lerp(initialScale, targetScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;  // Tunggu satu frame
        }

        // Pastikan gambar benar-benar menghilang dengan skala 0
        image.transform.localScale = targetScale;
    }
}
