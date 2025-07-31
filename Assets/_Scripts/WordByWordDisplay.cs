using System.Collections;
using UnityEngine;
using TMPro;

public class WordByWordDisplay : MonoBehaviour
{
    public TextMeshPro textMeshPro; // Pilih objek TextMeshPro di Inspector
    public float delay = 0.5f; // Waktu jeda antar kata
    public float displayDuration = 20f; // Durasi tampilan sebelum teks menghilang

    private void Start()
    {
        if (textMeshPro != null)
        {
            // Simpan teks asli dan mulai menampilkan kata per kata
            string fullText = textMeshPro.text;
            StartCoroutine(DisplayTextByWord(fullText));
        }
        else
        {
            Debug.LogError("Komponen TextMeshProUGUI belum diatur di Inspector!");
        }
    }

    private IEnumerator DisplayTextByWord(string fullText)
    {
        string[] words = fullText.Split(' '); // Pecah teks menjadi kata-kata
        textMeshPro.text = ""; // Kosongkan teks awal

        foreach (string word in words)
        {
            textMeshPro.text += word + " "; // Tambahkan kata ke teks
            yield return new WaitForSeconds(delay); // Tunggu sesuai jeda
        }

        // Tunggu selama displayDuration sebelum mengosongkan teks
        yield return new WaitForSeconds(displayDuration);
        textMeshPro.text = ""; // Kosongkan teks
    }
}
