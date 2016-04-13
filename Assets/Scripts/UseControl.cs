using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class UseControl : MonoBehaviour
{

    public float DistanceUse;

    public List<Key> Item;

    public GameObject HelpPanel;

	// Use this for initialization
	void Start () {
	
	}

	void Update ()
	{
        /*DEBUG*/
	    var textPanel = GameObject.Find("TextHelp").GetComponent<Text>();
	    var str = "Item:\n";
	    foreach (var i in Item)
	        str += i + "\n";
	    textPanel.text = str;
        /*END DEBUG*/

		var turn = new Vector2(Mathf.Sign(transform.FindChild("Img").transform.lossyScale.x), 0);
		turn.Normalize();
	    var items = Physics2D.RaycastAll(transform.position, turn, DistanceUse);
		if (items.Select(e => e.transform.tag).Count(e => e.Contains("Key")) != 0)
	    {
	        var keys = items.Where(e => e.transform.tag.Contains("Key"));
	        foreach (var key in keys)
	        {
	            Item.Add(key.transform.GetComponentInChildren<Key>());
                Destroy(key.transform.gameObject);
	        }
	    }
	    if (items.Select(e => e.transform.tag).Contains("Door"))
	    {
	        var door = items.First(e => e.transform.tag.Contains("Door")).transform.GetComponent<DoorControl>();
            HelpPanel.SetActive(true);
	        if (Input.GetKeyDown(KeyCode.E))
	        {
	            for (var i = 0; i < Item.Count; i++)
	            {
	                var it = Item[i];
	                if (it.ColorKey != door.ColorDoor) continue;
	                door.OpenDoor(it);
	                Item.Remove(it);
	                break;
	            }
	        }
	    }
        else
        {
            HelpPanel.SetActive(false);
        }
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position,
                new Vector2(transform.position.x + DistanceUse * Mathf.Sign(transform.FindChild("Img").transform.lossyScale.x), 
                            transform.position.y));

    }
}
