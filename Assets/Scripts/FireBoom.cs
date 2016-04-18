using UnityEngine;
using System.Collections;

public class FireBoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void Fire()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<Animator>().SetBool("Fire", true);
    }
}
