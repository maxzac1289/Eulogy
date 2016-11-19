using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Avilities : MonoBehaviour {

    public bool nextStage = false;
    public Dictionary<float, char> abilities1 = new Dictionary<float, char>();

	// Use this for initialization
	void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
	


}
