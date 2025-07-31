using UnityEngine;

public class nextscond : MonoBehaviour
{
    // Durasi tutorial yang bisa dipilih melalui Inspector
    public float tutorialDuration = 30f;
    private float tutorialTimer = 0f;
    private bool tutorialSkipped = false;

    // Fungsi untuk mendeteksi klik pada objek dengan BoxCollider2D
    private void OnMouseDown()
    {
        // Ketika DropButton diklik, tutorial langsung dilanjutkan ke detik tertentu
        SkipTutorial(tutorialDuration);
    }

    // Fungsi untuk skip tutorial sampai ke waktu yang ditentukan
    private void SkipTutorial(float targetTime)
    {
        // Menghentikan tutorial pada waktu tertentu
        tutorialTimer = targetTime;  // Langsung set tutorialTimer ke waktu yang ditentukan
        tutorialSkipped = true;
        EndTutorial();
    }

    // Fungsi untuk mengakhiri tutorial setelah skip
    private void EndTutorial()
    {
        // Menampilkan log yang menunjukkan tutorial sudah dilewati ke waktu yang ditentukan
        Debug.Log("Tutorial dilewati, melanjutkan ke detik: " + tutorialTimer);
    }

    // Update dipanggil setiap frame
    private void Update()
    {
        // Jika tutorial sudah dilewati, tidak perlu terus memperbarui timer
        if (tutorialSkipped)
            return;

        // Menambah timer setiap frame
        tutorialTimer += Time.deltaTime;

        // Jika waktu tutorial sudah selesai
        if (tutorialTimer >= tutorialDuration)
        {
            tutorialTimer = tutorialDuration;  // Pastikan timer tidak melebihi durasi
            EndTutorial();
        }
    }
}
