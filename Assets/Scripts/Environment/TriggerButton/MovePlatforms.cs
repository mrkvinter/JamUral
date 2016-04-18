using UnityEngine;
using System.Collections;

public class MovePlatforms : MonoBehaviour {

	public GameObject target;
	public Transform[] path;

	void OnTriggerEnter2D(Collider2D other)
	{ 
		if (target != null && other.gameObject.tag == "Player") {
			target.AddComponent<MoveableObject> ();
			target.GetComponent<MoveableObject> ().Path = path;
			target.GetComponent<MoveableObject> ().Speed = 2.5f;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Destroy (target.GetComponent<MoveableObject>());
	}
}
