using UnityEngine;
using System.Collections;

public class eleccoll : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GetComponent<SpriteRenderer>().enabled == true)
        {
            if (other.tag == "Player")
            {
                other.GetComponent<PlayerTime>().Die();
            }
        }
    }
}
