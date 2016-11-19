using UnityEngine;
using System.Collections;

public class coll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    GetComponent<GUIText>().text = "" + GameObject.Find("PlayerTime").GetComponent<PlayerTime>().timeabt;
	}
}
