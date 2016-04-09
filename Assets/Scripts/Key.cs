using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour
{

    public ColorKey ColorKey;
	// Use this for initialization
	void Start () {
        if (ColorKey == ColorKey.Red)
            GetComponent<SpriteRenderer>().color = Color.red;
        if (ColorKey == ColorKey.Green)
            GetComponent<SpriteRenderer>().color = Color.green;
        if (ColorKey == ColorKey.Blue)
            GetComponent<SpriteRenderer>().color = Color.blue;
    }


    public override string ToString()
    {
        return "Key " + ColorKey;
    }

    void OnDrawGizmos()
    {
        if (ColorKey == ColorKey.Red)
            GetComponent<SpriteRenderer>().color = Color.red;
        if (ColorKey == ColorKey.Green)
            GetComponent<SpriteRenderer>().color = Color.green;
        if (ColorKey == ColorKey.Blue)
            GetComponent<SpriteRenderer>().color = Color.blue;

    }
}
