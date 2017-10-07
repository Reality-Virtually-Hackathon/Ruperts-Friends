using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollTest : MonoBehaviour {

	public bool state = true;
	Rigidbody[] rbs;
	Transform[] bones;
	public GameObject player;
	Animator ragdollAnim;
	// Use this for initialization
	void Start () {
		ragdollAnim = player.GetComponent<Animator> ();
		rbs = GetComponentsInChildren<Rigidbody> ();

		bones = new Transform[rbs.Length];

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			state = !state; 

			if (state == true) {//ragdoll to mecanim



				player.GetComponent<Animator> ().enabled = true;

				foreach (Rigidbody rb in rbs) {
					rb.isKinematic = true;
				}

				ragdollAnim.SetBool ("switch", true);

			} else {//mecanim to ragdoll

				player.GetComponent<Animator> ().enabled = false;
				int i = 0;
				foreach (Rigidbody rb in rbs) {
					if (rb != gameObject.GetComponent<Rigidbody>()) {
						rb.isKinematic = false;

					}
					bones [i] = rb.transform;
					i++;
				}
				 
				ragdollAnim.SetBool ("switch", false);

			}
		}


	}

	IEnumerator lerpPosition(){
		bool status = true;
		while (status) {
			int i = 0;
			foreach (Transform bone in bones) {
				if (bone.position != bones [i].position && bone.rotation != bones [i].rotation) { 

					bone.position = Vector3.MoveTowards (bone.position, bones [i].position, Time.deltaTime);
					bone.rotation = Quaternion.RotateTowards (bone.rotation, bones [i].rotation, Time.deltaTime);
					yield return new WaitForSeconds (Time.deltaTime);

				} else {
					status = false;
					yield return true;
				}
			}
		}
	}
}
