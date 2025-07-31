using UnityEngine;
using UnityEngine.SceneManagement;

public class switchmenu : MonoBehaviour
{
    // Waktu dalam detik sebelum berpindah scene
    public float timeToSwitch = 30f;
    private float timer = 0f;

    void Update()
    {
        // Menambahkan waktu yang berlalu setiap frame
        timer += Time.deltaTime;

        // Jika timer mencapai waktu yang ditentukan, pindah scene
        if (timer >= timeToSwitch)
        {
            SwitchScene();
        }
    }

    void SwitchScene()
    {
        // Gantilah dengan nama scene yang ingin dipindahkan
        SceneManager.LoadScene("0_MainMenu");
    }
}
