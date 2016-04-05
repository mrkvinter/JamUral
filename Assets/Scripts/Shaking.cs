using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ShakableObject
{
    public float ShakeAmt;
    public Transform ObjectTransform;
}

public class Shaking : MonoBehaviour
{
    public ShakableObject[] Shakable;

    private Vector3[] _originalPositions;
    private Quaternion[] _originalRotations;
    
    void Start() {
        _originalPositions = new Vector3[Shakable.Length];
        _originalRotations = new Quaternion[Shakable.Length];
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        _originalPositions = Shakable.Select(x => x.ObjectTransform.position).ToArray();
        _originalRotations = Shakable.Select(x => x.ObjectTransform.rotation).ToArray();
        InvokeRepeating("Shake", 0, .02f);
        InvokeRepeating("Rotate", 0, .1f);
        Invoke("StopShaking", .5f);
    }

    private static float GetQuakeAmt(float shakeAmt) {
        return Random.value * shakeAmt * 2 - shakeAmt;
    }

    private void Shake() {
        foreach (var t in Shakable) {
            t.ObjectTransform.Translate(GetQuakeAmt(t.ShakeAmt), GetQuakeAmt(t.ShakeAmt), 0);
        }
    }

    private void Rotate() {
        foreach (var t in Shakable) {
            t.ObjectTransform.Rotate(new Vector3(0, 0, 1), GetQuakeAmt(t.ShakeAmt) * 15);
        }
    }

    private void StopShaking() {
        CancelInvoke("Shake");
        CancelInvoke("Rotate");

        for (var i = 0; i < Shakable.Length; i++) {
            Shakable[i].ObjectTransform.position = _originalPositions[i];
            Shakable[i].ObjectTransform.rotation = _originalRotations[i];
        }
    }
}
