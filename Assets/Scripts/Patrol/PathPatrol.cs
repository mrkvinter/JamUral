using UnityEngine;
using System.Linq;
using System.Collections;
using UnitySampleAssets._2D;

public class PathPatrol : MonoBehaviour
{

    public Transform[] Path;

    private PlatformerCharacter2D move;
    private int numPath;

    private bool isAdd;

	// Use this for initialization
	void Start ()
	{
	    move = GetComponent<PlatformerCharacter2D>();
	    numPath = 0;
	    isAdd = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if ((Path[numPath].position - transform.position).magnitude < 0.5f)
	    {
            if (isAdd)
	            numPath++;
            else
                numPath--;

	        if (numPath >= Path.Length)
	        {
	            numPath--;
	            isAdd = false;
	        }
	        if (numPath < 0)
	        {
	            numPath++;
	            isAdd = true;
	        }
	    }

	    var turn = Path[numPath].position - transform.position;
	    var isJump = turn.y > 1f;

        move.Move(turn.normalized, false, isJump);
	}

    void OnDrawGizmos()
    {
        var img = Resources.Load<Sprite>(@"Source\Gizmos\WayPont");
        Gizmos.color = Color.green;
        for (var i = 1; i < Path.Length; i++)
            Gizmos.DrawLine(Path[i-1].position, Path[i].position);
    }
}
