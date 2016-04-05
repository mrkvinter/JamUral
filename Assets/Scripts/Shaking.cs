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

    private uint _calls;
    
    void Start() {
        _originalPositions = new Vector3[Shakable.Length];
        _originalRotations = new Quaternion[Shakable.Length];
    }

    void OnCollisionEnter2D(Collision2D coll) {
        Shake();
    }

    public void Shake() {
        if (_calls == 0)
        {
            _originalPositions = Shakable.Select(x => x.ObjectTransform.position).ToArray();
            _originalRotations = Shakable.Select(x => x.ObjectTransform.rotation).ToArray();
        }

        _calls++;
        InvokeRepeating("Translate", 0, .02f);
        InvokeRepeating("Rotate", 0, .1f);
        Invoke("StopShaking", .5f);
    }

    private static float GetQuakeAmt(float shakeAmt) {
        return Random.value * shakeAmt * 2 - shakeAmt;
    }

    private void Translate() {
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
        _calls--;

        if (_calls == 0)
        {
            CancelInvoke("Translate");
            CancelInvoke("Rotate");
        }

        for (var i = 0; i < Shakable.Length; i++) {
            Shakable[i].ObjectTransform.position = _originalPositions[i];
            Shakable[i].ObjectTransform.rotation = _originalRotations[i];
        }
    }
}
