using UnityEngine;
using System.Collections;
using System.Linq;

public class DemonUseControl : MonoBehaviour
{
    public float RadiusGrap = 1.5f;
    private bool isFirstDown;

    private GameObject item;

    private string[] typesForMove;
    //private string nameToMove = "Move";

	// Use this for initialization
	void Start ()
	{
	    item = null;
        typesForMove = new string[] { "Key", "Move" };

    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.E))
	    {
            if (!isFirstDown)
            {
                var itemK = Physics2D.OverlapCircleAll(transform.position, RadiusGrap).ToArray();

                foreach (var i in itemK.Where(i => typesForMove.Contains(i.transform.tag)))
                {
                    item = i.transform.gameObject;
                    item.GetComponent<BoxCollider2D>().isTrigger = true;
                    break;
                }
                isFirstDown = true;
            }
            else
            {
                DropItem();
            }
	    }

        if (item != null)
            item.transform.position = transform.position;
        else
            isFirstDown = false;
    }

    public void DropItem()
    {
        item.GetComponent<BoxCollider2D>().isTrigger = false;
        item = null;
        isFirstDown = false;
    }
}
