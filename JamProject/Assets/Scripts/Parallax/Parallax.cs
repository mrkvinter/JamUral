using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;

public class Parallax : MonoBehaviour
{
    public Transform[] Backgrounds;
    private ParallaxObject[] BackgroundsObject;
    public float Smothing;

    private Transform camera;
    private Vector3 previousPosCamera;

    void Awake()
    {
        camera = Camera.main.transform;
    }
	// Use this for initialization
	void Start ()
	{
	    previousPosCamera = camera.position;
        BackgroundsObject = new ParallaxObject[Backgrounds.Length];
	    for (var i = 0; i < BackgroundsObject.Length; i++)
	        BackgroundsObject[i] = new ParallaxObject(Backgrounds[i], Backgrounds[i].position.z*-1);
	   
	}
	
	// Update is called once per frame
	void Update () {
	    for (var i = 0; i < BackgroundsObject.Length; i++)
	    {
	        var parallax = (previousPosCamera.x - camera.position.x)*BackgroundsObject[i].ParallaxScale;

	        var backgroundTargetPosX = BackgroundsObject[i].Background.position.x + parallax;

            var backgroundTargetPos = new Vector3((float)backgroundTargetPosX, 
                                                    BackgroundsObject[i].Background.position.y,
                                                    BackgroundsObject[i].Background.position.z);
	        BackgroundsObject[i].Background.position = Vector3.Lerp(BackgroundsObject[i].Background.position,
	                                                backgroundTargetPos,
	                                                Smothing*Time.deltaTime);
	    }

	    previousPosCamera = camera.position;
	}
}
