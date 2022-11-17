using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] string[] dialogue = new string[4];
    private int slideNumber = 0;
    [SerializeField] GameObject tutorialText;
    bool tutorial = true;
    private GameObject ThisText = GameObject.Find("Narrator");
    [SerializeField] GameObject Crowley;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (tutorial)
            {
                tutorialText.SetActive(false);
                tutorial = false;

                Crowley.SetActive(true);


                gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
            }

           
            else if (slideNumber < dialogue.Length - 1)
            {

                slideNumber++;
                SlideShow();
            }
            else
            {
                SceneManager.LoadScene(1);
            }

        }
    }
    void SlideShow()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = dialogue[slideNumber];
       
    }
}
