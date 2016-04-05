using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Flashing : MonoBehaviour
{
    public Image[] Flashable;

    private Color[] _originalColors;

    private uint _calls;

    void Start() {
        _originalColors = new Color[Flashable.Length];
    }

    void OnCollisionEnter2D(Collision2D coll) {
        Flash();
    }

    public void Flash() {
        if (_calls == 0)
        {
            _originalColors = Flashable.Select(x => x.color).ToArray();
        }

        _calls++;
        Invoke("MakeBlack", 0f);
        Invoke("MakeWhite", .03f);
        Invoke("TurnColorsBack", .06f);
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
        _calls--;

        for (var i = 0; i < Flashable.Length; i++) {
            Flashable[i].color = _originalColors[i];
        }
    }

}
