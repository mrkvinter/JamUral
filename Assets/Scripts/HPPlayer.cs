using UnityEngine;
using System.Collections;

public class HPPlayer : MonoBehaviour, IDead
{
    Animator anim;

    internal bool IsDead;

    public GameObject Menu;

    public Transform CheckPoint;

    // Use this for initialization
    void Start () {

        anim = transform.FindChild("Img").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {


        //if (IsDead && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        //{
        //    if (CheckPoint != null)
        //    {
        //        IsDead = false;
        //        //transform.FindChild("Img").GetComponent<Animator>().SetBool("Idle", true);
        //        transform.position = CheckPoint.position;
        //    }
        //}



    }

    public void Dead(string message, params object[] parametrs)
    {
        if (!IsDead)
        {
            IsDead = true;
            if (message == "Saw")
            {
                var otherTransform = (Transform)parametrs[0];
                var force = (otherTransform.position - transform.position) * 100;
                var rg = GetComponent<Rigidbody2D>();
                GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
                transform.FindChild("Img").GetComponent<Animator>().SetBool("Dead", true);
            }

            //  Menu.SetActive(true);

            if (CheckPoint != null)
            {
                IsDead = false;
                transform.FindChild("Img").GetComponent<Animator>().SetBool("Dead", false);
                transform.position = CheckPoint.position;
            }
        }
    }
}
