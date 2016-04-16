using UnityEngine;
using Assets.Scripts;
using System.Collections;
using System;

public class BoomFromTrigger : MonoBehaviour, ITriggerable
{
    private bool isTriggered;

    //public 

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (isTriggered)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0 , 0);
        }
	}

    public void OnTriggerEnter()
    {
        isTriggered = true;
    }

    public void OnTriggerExit()
    {
        
    }
}
