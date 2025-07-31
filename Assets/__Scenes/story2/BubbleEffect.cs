using UnityEngine;

public class BubbleEffect : MonoBehaviour
{
    public float delay = 3f; // Waktu tunda dalam detik
    public float bubbleDuration = 1f; // Durasi efek gelembung
    public Vector3 bubbleScale = new Vector3(1.5f, 1.5f, 1f); // Ukuran gelembung maksimum

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale; // Simpan skala asli
        transform.localScale = Vector3.zero; // Sembunyikan di awal
        Invoke(nameof(StartBubbleEffect), delay); // Mulai dengan delay
    }

    void StartBubbleEffect()
    {
        StartCoroutine(BubbleEffectCoroutine());
    }

    private System.Collections.IEnumerator BubbleEffectCoroutine()
    {
        float timer = 0f;

        while (timer < bubbleDuration)
        {
            timer += Time.deltaTime;
            float progress = timer / bubbleDuration;

            // Interpolasi antara skala asli dan gelembung
            transform.localScale = Vector3.Lerp(Vector3.zero, bubbleScale, progress);

            yield return null;
        }

        // Kembali ke ukuran asli setelah efek selesai
        transform.localScale = originalScale;
    }
}
