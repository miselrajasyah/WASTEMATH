using UnityEngine;
using UnityEngine.SceneManagement;  // Untuk mengakses Scene Management

public class nextbutton1 : MonoBehaviour
{
    // Fungsi ini akan dipanggil ketika gambar yang memiliki collider diklik
    private void OnMouseDown()
    {
        // Mengubah scene ke scene "0_MainMenu"
        SceneManager.LoadScene("story2");
    }
}
