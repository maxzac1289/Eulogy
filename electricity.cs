using UnityEngine;
using System.Collections;

public class electricity : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GetComponent<SpriteRenderer>().enabled == true)
        {
            if (other.tag == "Player")
            {
                other.GetComponent<PlayerWeather>().Die();
            }
        }
    }
}
