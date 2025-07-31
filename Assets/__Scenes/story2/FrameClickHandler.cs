using UnityEngine;

public class FrameClickHandler : MonoBehaviour
{
    public GameObject correctImage; // Panel "Correct"
    public GameObject wrongImage;   // Panel "Wrong"
    public float delayBeforeNextQuestion = 2f; // Waktu tunggu sebelum mengganti soal

    private QuizManager quizManager; // Referensi ke QuizManager

    void Start()
    {
        // Cari referensi ke QuizManager
        quizManager = FindObjectOfType<QuizManager>();
    }

    void OnMouseDown()
    {
        // Logika untuk opsi yang dipilih
        if (gameObject.name == "framepisang")
        {
            correctImage.SetActive(true);  // Tampilkan panel "Correct"
            wrongImage.SetActive(false);  // Pastikan panel "Wrong" mati
            Debug.Log("Pisang dipilih: Correct");

            // Panggil NextQuestion dengan isCorrect = true (jawaban benar)
            Invoke("SwitchToNextQuestion", delayBeforeNextQuestion);
        }
        else if (gameObject.name == "framebotol")
        {
            correctImage.SetActive(false); // Pastikan panel "Correct" mati
            wrongImage.SetActive(true);   // Tampilkan panel "Wrong"
            Debug.Log("Botol dipilih: Wrong");

            // Panggil NextQuestion dengan isCorrect = false (jawaban salah)
            Invoke("SwitchToNextQuestion", delayBeforeNextQuestion);
        }
    }

    void SwitchToNextQuestion()
    {
        // Panggil fungsi di QuizManager untuk ganti soal
        if (quizManager != null)
        {
            bool isCorrect = (gameObject.name == "framepisang");
            quizManager.NextQuestion(isCorrect);  // Pass isCorrect sesuai dengan pilihan
        }
    }
}
