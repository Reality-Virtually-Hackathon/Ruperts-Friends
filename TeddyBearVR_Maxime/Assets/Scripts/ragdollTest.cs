using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollTest : MonoBehaviour {

	public Animator ragdoll;
	public bool state = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			ragdoll.SetBool("switch",!state);
			state = !state; 
		}
	}
}
