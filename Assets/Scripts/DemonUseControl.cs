using UnityEngine;
using System.Collections;
using System.Linq;

public class DemonUseControl : MonoBehaviour
{
    public float RadiusGrap = 1.5f;
    private bool isFirstDown;

    private GameObject item;
    private float oldGravityScale;

    private string[] typesForMove;
    //private string nameToMove = "Move";

	// Use this for initialization
	void Start ()
	{
	    item = null;
        typesForMove = new [] { "Key", "Move" };

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
                    oldGravityScale = item.GetComponent<Rigidbody2D>().gravityScale;
                    item.GetComponent<Rigidbody2D>().gravityScale = 0;
                    //item.GetComponent<BoxCollider2D>().isTrigger = true;
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
	    {
	        var direct = (transform.position - item.transform.position);

            if (direct.magnitude > 0.6f)
	        {
	            var direction = direct.normalized*500*Time.deltaTime;
	            if (direct.magnitude < 1) direction = direct*100*Time.deltaTime;
	            //item.transform.position += direction;
	            //item.transform.position = Vector2.MoveTowards(item.transform.position, transform.position, 0.1f);
	            
	            item.GetComponent<Rigidbody2D>().velocity = direction;
                //item.GetComponent<Rigidbody2D>().AddForce(direction/100);
	        }
	    }
	    else
	        isFirstDown = false;
	}

    public void DropItem()
    {
        item.GetComponent<Rigidbody2D>().gravityScale = oldGravityScale;
        item = null;
        isFirstDown = false;
    }
}
