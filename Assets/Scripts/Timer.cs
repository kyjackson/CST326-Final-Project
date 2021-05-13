using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public bool finished = false;
    public Text timeText;
    public Text statusText;
    public GameObject finishZone;

    private void Start()
    {
        finishZone = GameObject.Find("FinishTrigger");
    }

    // Update is called once per frame
    void Update()
    {
        if(timeValue > 0)
        {
            timeValue = timeValue - Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);

        if (finished)
        {
            statusText.text = "Finished!";
            StartCoroutine("NextScene");
        } 
        else if (!finished && timeValue <= 0)
        {
            Destroy(finishZone);
            statusText.text = "Did not finish. Try again!";
            StartCoroutine("ReloadScene");
        }
        
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
