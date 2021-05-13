using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public GameObject endMessage;
    public Timer timer;

    private void Start()
    {
        timer = GameObject.Find("TimerText").GetComponent<Timer>();
        //endMessage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //endMessage.SetActive(true);
            //StartCoroutine("WaitForSec");
            timer.finished = true;
            Debug.Log("Finished");
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(endMessage);
        Destroy(gameObject);
    }
}
