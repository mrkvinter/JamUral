using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class SwitchMonster : MonoBehaviour
{
    public GameObject Player;
    public GameObject Monster;

    private Camera2DFollow follow;

    private bool IsMonster = false;

	// Use this for initialization
	void Start ()
	{
	    follow = Camera.main.GetComponent<Camera2DFollow>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.LeftShift))
	    {
	        IsMonster = true;
            Monster.GetComponent<Transform>().position = Player.GetComponent<Transform>().position;
            Player.GetComponent<Platformer2DUserControl>().IsDemon = true;
	        follow.target = Monster.transform;
	        Monster.SetActive(true);
	    }
	    if (Input.GetKeyUp(KeyCode.LeftShift))
	    {
	        IsMonster = false;
            Player.GetComponent<Platformer2DUserControl>().IsDemon = false;
	        follow.target = Player.transform;
            Monster.SetActive(false);
        }
	}
}
