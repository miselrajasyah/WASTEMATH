using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshProController : MonoBehaviour
{
    [Tooltip("Parent objects (like rudi1, rudi2) containing TMP components.")]
    public List<GameObject> textGroups;

    [Tooltip("Delay before starting the sequence (in seconds).")]
    public float startDelay = 5f;

    [Tooltip("Delay between each text group (in seconds).")]
    public float groupDelay = 2f;

    [Tooltip("Speed of displaying each word (in seconds).")]
    public float wordSpeed = 0.5f;

    void Start()
    {
        StartCoroutine(DisplayTextGroups());
    }

    IEnumerator DisplayTextGroups()
    {
        // Hide all groups initially
        foreach (var group in textGroups)
        {
            group.SetActive(false);
        }

        // Delay before starting
        yield return new WaitForSeconds(startDelay);

        // Iterate over each group
        foreach (var group in textGroups)
        {
            // Activate the current group
            group.SetActive(true);

            // Get all TextMeshPro components inside the group
            var tmps = group.GetComponentsInChildren<TextMeshPro>();

            // Display each TMP text word by word
            foreach (var tmp in tmps)
            {
                if (tmp != null)
                {
                    string fullText = tmp.text;
                    tmp.text = "";

                    string[] words = fullText.Split(' ');
                    foreach (var word in words)
                    {
                        tmp.text += word + " ";
                        yield return new WaitForSeconds(wordSpeed);
                    }
                }
            }

            // Deactivate the group after showing the text
            yield return new WaitForSeconds(groupDelay);
            group.SetActive(false);
        }
    }
}
