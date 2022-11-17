using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class outro : MonoBehaviour
{
    [SerializeField] GameObject newBackground;
    [SerializeField] GameObject newText;
    [SerializeField] string[] dialogue;
    private int slideNumber = 0;

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (slideNumber < dialogue.Length - 1)
            {
                slideNumber++;
                SlideShow();
            }
            else
            {
                gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
                newText.SetActive(true);
                newBackground.SetActive(true);
            }
        }
    }
    void SlideShow()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = dialogue[slideNumber];
    }
}
