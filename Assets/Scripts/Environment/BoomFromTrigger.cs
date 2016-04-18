using UnityEngine;
using Assets.Scripts;
using System.Collections;
using System;
using System.Linq;

public class BoomFromTrigger : MonoBehaviour, ITriggerable
{
    private bool isTriggered;

    public float RadiusBoom = 5;
    public GameObject FireBoom;

    public float timeToBoom = 5f;
    public float stepToBoom = 0.8f;
    public bool isRed = false;

    public float powerDamage = 50;

    public bool isBoom = false;

    //public 

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (isTriggered)
        {
            timeToBoom -= stepToBoom;
            if (isRed)
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
            else
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            isRed = !isRed;

            if (timeToBoom <= 0)
            {
                isTriggered = false;
                GetComponent<BOOM>().Boom();
            }
        }
	}

    public void OnTriggerEnter()
    {
        isTriggered = true;
    }

    public void Boom()
    {
        isBoom = true;

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

                //if (F.x == 0 || F.y == 0)
                //    F = new Vector2(powerDamage, powerDamage);
                //else
                //{
                //    if (F.x != 0)
                //        F = new Vector2(RadiusBoom / F.x, F.y);
                //    if (F.y != 0)
                //        F = new Vector2(F.x, RadiusBoom / F.y);
                //}

                //if (F.x > powerDamage)
                //    F = new Vector2(powerDamage, F.y);

                //if (F.y > powerDamage)
                //    F = new Vector2(F.x, powerDamage);

                F = new Vector2(powerDamage, powerDamage);
                rg.AddForce(new Vector2((F.x + Mathf.Sign(F.x)), F.y) * 0.01f);
              //  rg.AddTorque(UnityEngine.Random.Range(-120, 120));
            }

            var otherBoom = d.GetComponent<BoomFromTrigger>();
            if (otherBoom != null && !otherBoom.isBoom)
                otherBoom.Boom();
        }

        Destroy(gameObject);
    }

    

    public void OnTriggerExit()
    {
        
    }
}
