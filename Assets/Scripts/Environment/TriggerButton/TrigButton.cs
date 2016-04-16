using UnityEngine;
using Assets.Scripts;
using System.Collections;

public class TrigButton : MonoBehaviour {

    public GameObject target;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (target != null && other.gameObject.tag == "Player")
            target.GetComponent<ITriggerable>().OnTriggerEnter();
    }
    //---------------------------------------------------------------------------
    void OnTriggerExit2D(Collider2D other)
    { 
        if (target != null && other.gameObject.tag == "Player")
            target.GetComponent<ITriggerable>().OnTriggerExit();
    }
}
