using UnityEngine;
using System.Collections;

public class TrigButton : MonoBehaviour {

    public GameObject target;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (target != null)
            target.GetComponent<StakesMove>().OnTriggerEnter();
    }
    //---------------------------------------------------------------------------
    void OnCollisionExit2D(Collision2D other)
    { 
        if (target != null)
            target.GetComponent<StakesMove>().OnTriggerExit();
    }
}
