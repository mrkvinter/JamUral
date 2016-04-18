using UnityEngine;
using System.Collections;
using System.Linq;

public class BOOM : MonoBehaviour
{

    public float RadiusBoom = 5;
    public GameObject FireBoom;

    public bool isBoom;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Boom()
    {
        isBoom = true;
        //GetComponent<AudioSource>().Play();
        var g = (GameObject)Instantiate(FireBoom, transform.position, Quaternion.identity);
        Debug.Log("GOOD");
        var f = g.GetComponentInChildren<FireBoom>();
        if (f != null)
        {
            f.Fire();
            Debug.Log("FIRE GOOD");
        }
        else
        {
            Debug.Log("FIRE NOT");
        }
        var itemsInBoom = Physics2D.OverlapCircleAll(transform.position, RadiusBoom);
        itemsInBoom = itemsInBoom.Where(e => !e.gameObject.Equals(gameObject)).ToArray();

        foreach (var d in itemsInBoom)
        {
            var hp = d.GetComponent<HPPlayer>();
            if (hp != null) hp.Dead("Boom");

            var rg = d.GetComponent<Rigidbody2D>();
            if (rg != null && rg.transform.tag != "Demon")
            {
                var F = d.transform.position - transform.position;

                if (F.x == 0 || F.y == 0)
                    F = new Vector2(100, 100);
                else
                {
                    if (F.x != 0)
                        F = new Vector2(RadiusBoom / F.x, F.y);
                    if (F.y != 0)
                        F = new Vector2(F.x, RadiusBoom / F.y);
                }

                if (F.x > 100)
                    F = new Vector2(100, F.y);

                if (F.y > 100)
                    F = new Vector2(F.x, 100);
                rg.AddForce(new Vector2(1000 * (F.x + 5 * Mathf.Sign(F.x)), 700 * F.y + 2000)*0.1f);
                rg.AddTorque(Random.Range(-120, 120));
            }

            var otherBoom = d.GetComponent<BOOM>();
            if (otherBoom != null && !otherBoom.isBoom)
                otherBoom.Boom();
        }

        Destroy(gameObject);
    }
}
