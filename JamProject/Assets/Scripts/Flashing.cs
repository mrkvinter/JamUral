using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Flashing : MonoBehaviour
{
    public Image[] Flashable;

    private Color[] _originalColors;

    void Start() {
        _originalColors = new Color[Flashable.Length];
    }

    void OnCollisionEnter2D(Collision2D coll) {
        _originalColors = Flashable.Select(x => x.color).ToArray();
        Invoke("MakeBlack", 0f);
        Invoke("MakeWhite", .02f);
        Invoke("TurnColorsBack", .04f);
    }

    private void SetColor(Color color) {
        foreach (var image in Flashable) {
            image.color = color;
        }
    }

    private void MakeBlack() {
        SetColor(Color.black);
    }

    private void MakeWhite() {
        SetColor(Color.white);
    }

    private void MakeClear() {
        SetColor(Color.clear);
    }

    private void TurnColorsBack() {
        for (var i = 0; i < Flashable.Length; i++) {
            Flashable[i].color = _originalColors[i];
        }
    }

}
