using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {

    void OnDrawGizmos()
    {
        var img = Resources.Load<Sprite>(@"Source\Gizmos\WayPont");
        Gizmos.DrawIcon(transform.position, @"Source\Gizmos\WayPont");
    }
}
