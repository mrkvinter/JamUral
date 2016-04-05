using UnityEngine;
using System.Collections;

public class ClickButton : MonoBehaviour {

    public void OnClick()
    {
        Debug.Log("I was clicked and I make a gold");
        EventManager.Invoke("AddMoney");
    }
}
