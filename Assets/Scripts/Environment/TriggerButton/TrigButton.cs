using UnityEngine;
using Assets.Scripts;
using System.Collections;
using System;

public class TrigButton : MonoBehaviour {

	public GameObject target;

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.tag == "Player")
            target.GetComponent<ITriggerable>().OnTriggerEnter();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            target.GetComponent<ITriggerable>().OnTriggerExit();
    }

    //IEnumerable Fall() {
    //	foreach (var cht in target.GetComponentsInChildren<Transform>()) {
    //		cht.gameObject.AddComponent<Rigidbody2D> ();
    //		yield return new WaitForSeconds (1);
    //	}
    //}

}
