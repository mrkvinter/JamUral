using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AddScore : MonoBehaviour {

    public Text txtRef;

    public int money = 400;

    void Start()
    {
        EventManager.AddListener("AddMoney", AddMoney);
        SetText(string.Format("Score: {0}", money));
    }

    void SetText(string text)
    {
        if (txtRef != null)
            txtRef.text = text;
    }

    public void AddMoney()
    {
        money += 100;
        SetText(string.Format("Score: {0}", money));
        Debug.Log("Event AddScore was passed");
    }
}
