using UnityEngine;
using Assets.Scripts;
using System.Collections;

public class TrigButton : MonoBehaviour {

	public GameObject target;

	void OnTriggerExit2D(Collider2D other)
	{
		if (target != null && other.gameObject.tag == "Player")
			foreach (var _ in Fall ()) { }
    }

	IEnumerable Fall() {
		foreach (var cht in target.GetComponentsInChildren<Transform>()) {
			cht.gameObject.AddComponent<Rigidbody2D> ();
			yield return new WaitForSeconds (1);
		}
	}
}
