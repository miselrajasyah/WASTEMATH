using UnityEngine;

public class fadein : MonoBehaviour
{
    public float delay = 3f; // Waktu tunda dalam detik
    public float moveDuration = 1f; // Durasi pergerakan ke posisi akhir
    public float overshootAmount = 0.2f; // Overshoot jarak (lebih tinggi dari posisi akhir)
    public Vector3 startOffset = new Vector3(0f, -2f, 0f); // Posisi awal relatif terhadap posisi akhir

    private Vector3 targetPosition; // Posisi akhir

    void Start()
    {
        // Simpan posisi akhir dan set posisi awal
        targetPosition = transform.position;
        transform.position += startOffset;

        Invoke(nameof(StartMoveEffect), delay); // Mulai efek setelah delay
    }

    void StartMoveEffect()
    {
        StartCoroutine(MoveFromBelowCoroutine());
    }

    private System.Collections.IEnumerator MoveFromBelowCoroutine()
    {
        float timer = 0f;
        Vector3 overshootPosition = targetPosition + new Vector3(0, overshootAmount, 0);

        // Gerakan ke posisi overshoot
        while (timer < moveDuration / 2)
        {
            timer += Time.deltaTime;
            float progress = timer / (moveDuration / 2);
            transform.position = Vector3.Lerp(transform.position, overshootPosition, Mathf.SmoothStep(0f, 1f, progress));
            yield return null;
        }

        timer = 0f;

        // Gerakan kembali ke posisi akhir
        while (timer < moveDuration / 2)
        {
            timer += Time.deltaTime;
            float progress = timer / (moveDuration / 2);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Mathf.SmoothStep(0f, 1f, progress));
            yield return null;
        }

        // Pastikan objek berada tepat di posisi akhir
        transform.position = targetPosition;
    }
}
