using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (GetComponent<Animator>().GetBool("spiderDead") == false)
        {
            if (other.tag == "Player")
            {
                other.GetComponent<PlayerWeather>().Die();
            }
        }
    }
}
