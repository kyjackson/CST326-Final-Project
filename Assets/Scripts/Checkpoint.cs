using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] public Transform player;
    //[SerializeField] public Transform checkPoint;
    [SerializeField] public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            respawnPoint.transform.position = transform.position;
            Physics.SyncTransforms();
        }
    }
}
