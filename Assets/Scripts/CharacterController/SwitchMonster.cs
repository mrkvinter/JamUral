using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class SwitchMonster : MonoBehaviour
{
    public GameObject Player;
    public GameObject Monster;

    private bool IsMonster = false;

	// Use this for initialization
	void Start ()
	{
        //Monster.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.LeftShift))
	    {
	        IsMonster = true;
            Monster.GetComponent<Transform>().position = Player.GetComponent<Transform>().position;
            Player.GetComponent<Platformer2DUserControl>().enabled = false;
	        //gameObject.SetActive(false);
	        Monster.SetActive(true);
	    }
	    if (Input.GetKeyUp(KeyCode.LeftShift))
	    {
	        IsMonster = false;
            Player.GetComponent<Platformer2DUserControl>().enabled = true;
            Monster.SetActive(false);
        }
	}
}
