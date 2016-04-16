using UnityEngine;
using System.Collections;

public class MoveableObject : MonoBehaviour {

    public Transform[] Path;
    public float Speed = 1;

    private int numPath;
    private bool isAdd;

    void Start()
    {
        numPath = 0;
        isAdd = true;
    }

    void Update()
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
        transform.Translate(turn.normalized * Speed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        var img = Resources.Load<Sprite>(@"Source\Gizmos\WayPont");
        Gizmos.color = Color.green;
        for (var i = 1; i < Path.Length; i++)
            Gizmos.DrawLine(Path[i - 1].position, Path[i].position);
    }
}
