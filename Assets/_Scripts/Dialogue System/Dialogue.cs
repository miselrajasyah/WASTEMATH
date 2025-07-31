using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI speakerName;
    public Button nextButton;
    public string[] lines;
    public AudioClip[] linesAudio;
    public float textSpeed;

    [SerializeField] GameObject pointer, questionPanel;

    /*[Header ("Deactivate Buttons")]*/
    [SerializeField] 
    Button option1, option2, option3, pauseBTN, hintBTN;

    float xPointPos, yPointPos;
    private AudioSource audioSource;
    private int index;
    void Start()
    {
        option1.enabled = false;
        option2.enabled = false;
        option3.enabled = false;
        pauseBTN.enabled = false;
        hintBTN.enabled = false;

        textComponent.text = string.Empty;
        audioSource = GetComponent<AudioSource>();
        StartDialogue();
    }

    public void TaskOnClick()
    {
        if (textComponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    void StartDialogue()
    {
        index = 0;
        speakerName.text = "Misel";
        StartCoroutine(TypeLine());
        audioSource.PlayOneShot(linesAudio[index]);
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            audioSource.Stop();
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            audioSource.PlayOneShot(linesAudio[index]);

            switch(index) {
                case 1:
                    xPointPos = (questionPanel.GetComponent<RectTransform>().localPosition.x) - (-90.66f);
                    yPointPos = (questionPanel.GetComponent<RectTransform>().localPosition.y) - (90.44f);
                    LeanTween.moveLocal(pointer, new Vector3(xPointPos, yPointPos, 0f), 0.7f).setDelay(.5f).setEase(LeanTweenType.easeOutCirc);
                    break;
                case 2:
                    xPointPos = (questionPanel.GetComponent<RectTransform>().localPosition.x) + (-170f);
                    yPointPos = (questionPanel.GetComponent<RectTransform>().localPosition.y) + (-294.9f);
                    LeanTween.moveLocal(pointer, new Vector3(xPointPos, yPointPos, 0f), 0.7f).setDelay(.2f).setEase(LeanTweenType.easeOutCirc);
                    LeanTween.moveLocal(pointer, new Vector3(xPointPos + 720f, yPointPos, 0f), 0.7f).setDelay(.9f).setEase(LeanTweenType.easeOutCirc);
                    break;
                case 3:
                    speakerName.text = "Maura";
                    xPointPos = (hintBTN.GetComponent<RectTransform>().localPosition.x) - (-101.66f);
                    yPointPos = (hintBTN.GetComponent<RectTransform>().localPosition.y) - (90.44f);
                    LeanTween.moveLocal(pointer, new Vector3(xPointPos, yPointPos, 0f), 0.7f).setDelay(.5f).setEase(LeanTweenType.easeOutCirc);
                    break;
                case 4:
                    xPointPos = (pauseBTN.GetComponent<RectTransform>().localPosition.x) - (-101.66f);
                    yPointPos = (pauseBTN.GetComponent<RectTransform>().localPosition.y) - (90.44f);
                    LeanTween.moveLocal(pointer, new Vector3(xPointPos, yPointPos, 0f), 0.7f).setDelay(.5f).setEase(LeanTweenType.easeOutCirc);
                    break;
            }
        }
        else
        {
            option1.enabled = true;
            option2.enabled = true;
            option3.enabled = true;
            pauseBTN.enabled = true;
            hintBTN.enabled = true;
            gameObject.SetActive(false);
        }
    }

    public void SkipTutorial() {
        audioSource.Stop();
        option1.enabled = true;
        option2.enabled = true;
        option3.enabled = true;
        pauseBTN.enabled = true;
        hintBTN.enabled = true;
        gameObject.SetActive(false);
    }


}
