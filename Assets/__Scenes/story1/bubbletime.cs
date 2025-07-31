using UnityEngine;
using System.Collections.Generic;

public class bubbletime : MonoBehaviour
{
    public List<BubbleState> bubbleSchedule = new List<BubbleState>(); // Jadwal muncul/hilang
    private int currentStateIndex = 0;
    private Vector3 originalScale;
    private bool isRunning = false;
    public float initialDelay = 2f; // Initial delay before starting the bubble effect

    void Start()
    {
        originalScale = transform.localScale; // Simpan skala asli
        transform.localScale = Vector3.zero; // Sembunyikan di awal
        if (bubbleSchedule.Count > 0)
        {
            StartCoroutine(StartWithInitialDelay());
        }
    }

    private System.Collections.IEnumerator StartWithInitialDelay()
    {
        // Wait for the initial delay
        yield return new WaitForSeconds(initialDelay);

        // After the initial delay, start the bubble schedule
        StartCoroutine(HandleBubbleSchedule());
    }

    private System.Collections.IEnumerator HandleBubbleSchedule()
    {
        isRunning = true;

        while (currentStateIndex < bubbleSchedule.Count)
        {
            var currentState = bubbleSchedule[currentStateIndex];
            if (currentState.isVisible)
            {
                StartCoroutine(BubbleEffectCoroutine(currentState.duration, true)); // Tampilkan
            }
            else
            {
                StartCoroutine(BubbleEffectCoroutine(currentState.duration, false)); // Hilangkan
            }

            yield return new WaitForSeconds(currentState.duration);
            currentStateIndex++;
        }

        isRunning = false;
    }

    private System.Collections.IEnumerator BubbleEffectCoroutine(float duration, bool show)
    {
        float timer = 0f;
        Vector3 targetScale = show ? originalScale : Vector3.zero;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;

            // Interpolasi antara ukuran sekarang dan target
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, progress);
            yield return null;
        }

        transform.localScale = targetScale; // Pastikan ukuran akhir sesuai
    }
}

[System.Serializable]
public class BubbleState
{
    public bool isVisible; // Apakah bubble harus terlihat
    public float duration; // Durasi dalam detik
}
