using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public enum ColorKey
{
    Red,
    Green,
    Blue
}

public class DoorControl : MonoBehaviour
{
    public ColorKey ColorDoor;

    public bool IsOpen;
	// Use this for initialization
	void Start ()
	{
	    IsOpen = false;
	    if (ColorDoor == ColorKey.Red)
	        GetComponent<SpriteRenderer>().color = Color.red;
        if (ColorDoor == ColorKey.Green)
            GetComponent<SpriteRenderer>().color = Color.green;
        if (ColorDoor == ColorKey.Blue)
            GetComponent<SpriteRenderer>().color = Color.blue;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenDoor(Key key)
    {
        if (key.ColorKey == ColorDoor)
        {
            IsOpen = true;
            GetComponent<Animator>().SetBool("Open", IsOpen);
        }
    }

    void OnDrawGizmos()
    {
        if (ColorDoor == ColorKey.Red)
            GetComponent<SpriteRenderer>().color = Color.red;
        if (ColorDoor == ColorKey.Green)
            GetComponent<SpriteRenderer>().color = Color.green;
        if (ColorDoor == ColorKey.Blue)
            GetComponent<SpriteRenderer>().color = Color.blue;

    }
}
