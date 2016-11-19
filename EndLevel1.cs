using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndLevel1 : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("stage 1.2");
            return;
        }
    }
}
