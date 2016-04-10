using UnityEngine;
using System.Collections;
using System.Linq;

public class DemonUseControl : MonoBehaviour
{

    private GameObject item;

	// Use this for initialization
	void Start ()
	{
	    item = null;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.E))
	    {
	        var itemK = Physics2D.OverlapCircleAll(transform.position, 3f).ToArray();
            
	        foreach (var i in itemK.Where(i => i.transform.tag == "Key"))
	        {
	            item = i.transform.gameObject;
	            break;
	        }
	    }
	    if (item != null)
	        item.transform.position = transform.position;
	}
}
