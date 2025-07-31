using System.Collections;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public GameObject[] questions; // Array soal
    public GameObject panelCorrect; // Panel Correct
    public GameObject panelWrong;   // Panel Wrong
    public int currentQuestionIndex = 0; // Indeks soal saat ini

    public AudioSource correctSound; // AudioSource untuk suara Correct
    public AudioSource wrongSound;   // AudioSource untuk suara Wrong

    void Start()
    {
        // Mulai soal pertama setelah delay 50 detik
        StartCoroutine(StartQuizWithDelay());
    }

    // Coroutine untuk memberikan delay sebelum soal pertama muncul
    IEnumerator StartQuizWithDelay()
    {
        // Mulai dengan menyembunyikan semua soal
        foreach (GameObject question in questions)
        {
            question.SetActive(false);
        }

        // Delay 50 detik sebelum soal pertama muncul
        yield return new WaitForSeconds(50);

        // Tampilkan soal pertama
        ShowCurrentQuestion();
    }

    // Fungsi untuk menampilkan soal berdasarkan currentQuestionIndex
    void ShowCurrentQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            // Menampilkan soal berdasarkan currentQuestionIndex
            questions[currentQuestionIndex].SetActive(true);
        }
    }

    // Fungsi untuk melanjutkan ke soal berikutnya setelah feedback (Correct/Wrong) muncul
    public void NextQuestion(bool isCorrect)
    {
        // Sembunyikan soal saat ini
        questions[currentQuestionIndex].SetActive(false);

        // Nonaktifkan panel feedback (Correct/Wrong)
        panelCorrect.SetActive(false);
        panelWrong.SetActive(false);

        // Mainkan suara berdasarkan apakah jawabannya benar atau salah
        if (isCorrect)
        {
            correctSound.Play(); // Mainkan suara correct
        }
        else
        {
            wrongSound.Play();   // Mainkan suara wrong
        }

        // Menunggu beberapa detik sebelum soal berikutnya muncul
        StartCoroutine(WaitForFeedbackAndNext());
    }

    // Fungsi untuk menunggu feedback dan melanjutkan ke soal berikutnya
    IEnumerator WaitForFeedbackAndNext()
    {
        // Delay untuk menunggu sebelum melanjutkan ke soal berikutnya
        yield return new WaitForSeconds(2);

        // Lanjutkan ke soal berikutnya
        currentQuestionIndex++;

        // Cek apakah masih ada soal berikutnya
        if (currentQuestionIndex < questions.Length)
        {
            // Tampilkan soal berikutnya
            ShowCurrentQuestion();
        }
        else
        {
            Debug.Log("Quiz selesai!");
            // Opsional: Tampilkan pesan selesai atau reset soal
        }
    }
}
