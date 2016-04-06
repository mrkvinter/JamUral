using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public GameObject ExitDoor;
	
//---------------------------------------------------------------------------
	void Start () {
	
	}
//---------------------------------------------------------------------------
	void Update () {
	
	}
//---------------------------------------------------------------------------
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.transform.position = ExitDoor.transform.position;
		}
	}
}