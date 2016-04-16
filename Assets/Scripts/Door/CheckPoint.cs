using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    public GameObject Door;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Door.GetComponent<DoorControl>().IsOpen && other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<HPPlayer>().CheckPoint = gameObject.transform;
        }
    }
}
