using UnityEngine;
using System.Collections;

public class HPPlayer : MonoBehaviour, IDead
{

    internal bool IsDead;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Dead(string message, params object[] parametrs)
    {
        if (!IsDead)
        {
            IsDead = true;
            if (message == "Saw")
            {
                var otherTransform = (Transform) parametrs[0];
                var force = (otherTransform.position - transform.position)*100;
                var rg = GetComponent<Rigidbody2D>();
                GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
                transform.FindChild("Img").GetComponent<Animator>().SetBool("Dead", true);
            }
        }
    }
}
