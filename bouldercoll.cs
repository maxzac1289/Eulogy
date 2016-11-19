using UnityEngine;
using System.Collections;

public class bouldercoll : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerTime>().Die();
        }
    }
}
