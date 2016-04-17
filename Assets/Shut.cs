using UnityEngine;
using System.Collections;
using System.Linq;

public class Shut : MonoBehaviour
{

    public GameObject[] Targets;
    public Collider2D Area;
    public GameObject Fire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Fire.GetComponent<Animator>().SetBool("Shut", false);
        var allGO = Physics2D.OverlapCircleAll(transform.position, 10f).Select(e => e.gameObject).ToArray();
	    foreach (var target in Targets)
	    {
	        if (allGO.Contains(target))
	            Shute(target);
	    }
	}

    void Shute(GameObject t)
    {
        Fire.GetComponent<Animator>().SetBool("Shut", true);
        var allT = Physics2D.RaycastAll(transform.position,
            Vector2.right*transform.FindChild("Img").transform.lossyScale.x,
            10f);
        foreach (var a in allT)
        {
            var c = a.transform.GetComponent<HPPlayer>();
            if (c != null)
                c.Dead("Shut");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (Targets.Contains(other.gameObject))
            Shute(other.gameObject);
        
    }
}
