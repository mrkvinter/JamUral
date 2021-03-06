﻿using System;
using UnityEngine;
using System.Collections;
using System.Linq;

public class Shut : MonoBehaviour
{

    public GameObject[] Targets;
    public GameObject Fire;
    public float Radius = 7f;

    public AudioSource ShutSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Fire.GetComponent<Animator>().SetBool("Shut", false);
        var allGO = Physics2D.OverlapCircleAll(transform.position, Radius).Select(e => e.gameObject).ToArray();
       
	    foreach (var target in Targets)
	    {
	        if (allGO.Contains(target) && 
                Math.Abs(Mathf.Sign((target.transform.position - transform.position).x) - Mathf.Sign(transform.FindChild("Img").transform.lossyScale.x)) < 0.001)
	            Shute(target);
	    }
	}

    void Shute(GameObject t)
    {
        if (!ShutSound.isPlaying)
            ShutSound.Play();

        Fire.GetComponent<Animator>().SetBool("Shut", true);
        var allT = Physics2D.RaycastAll(transform.position,
            Vector2.right * transform.FindChild("Img").transform.lossyScale.x,
            Radius);
        var c = allT[1].transform.GetComponent<HPPlayer>();
        if (c != null && Targets.Contains(allT[1].transform.gameObject))
        {
            c.Dead("Shut");
            Fire.GetComponent<Animator>().SetBool("Shut", false);
        }


        //foreach (var a in allT)
        //{
        //    var c = a.transform.GetComponent<HPPlayer>();
        //    if (c != null && Targets.Contains(a.transform.gameObject))
        //    {
        //        c.Dead("Shut");
        //        Fire.GetComponent<Animator>().SetBool("Shut", false);
        //    }
        //}
    }
}
