using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textrudicontrol : MonoBehaviour
{
    [Tooltip("List of TextMeshPro elements to control.")]
    public List<TextMeshPro> textElements;

    [Tooltip("List of delays for each TextMeshPro element (in seconds).")]
    public List<float> startDelays; // List of delays for each TextMeshPro element before starting

    [Tooltip("List of delays between showing each TextMeshPro (in seconds).")]
    public List<float> elementDelays; // Delay between each TextMeshPro element

    [Tooltip("List of speeds for displaying each word (in seconds).")]
    public List<float> wordSpeeds; // Speed of displaying words for each TextMeshPro element

    [Tooltip("List of delays before the text disappears (in seconds).")]
    public List<float> textFadeDelays; // Delay before the text disappears for each TextMeshPro

    void Start()
    {
        // Start the text display sequence
        StartCoroutine(DisplayTextElements());
    }

    IEnumerator DisplayTextElements()
    {
        // Hide all TMP elements initially
        foreach (var tmp in textElements)
        {
            if (tmp != null)
            {
                tmp.gameObject.SetActive(false);
            }
        }

        // Loop through each TMP element and apply the delays
        for (int i = 0; i < textElements.Count; i++)
        {
            if (textElements[i] != null)
            {
                // Delay before starting this text element (different for each element)
                yield return new WaitForSeconds(startDelays[i]);

                // Activate the TMP element
                textElements[i].gameObject.SetActive(true);

                // Save the original text and clear it
                string fullText = textElements[i].text;
                textElements[i].text = "";

                // Display text word by word with different speeds for each TMP element
                string[] words = fullText.Split(' ');
                foreach (string word in words)
                {
                    textElements[i].text += word + " ";
                    yield return new WaitForSeconds(wordSpeeds[i]);
                }

                // Wait for a set delay before hiding the current TMP
                yield return new WaitForSeconds(elementDelays[i]);

                // Optional: Delay before hiding the current TMP element
                yield return new WaitForSeconds(textFadeDelays[i]);

                // Hide the TMP element after delay
                textElements[i].gameObject.SetActive(false);
            }
        }
    }
}
