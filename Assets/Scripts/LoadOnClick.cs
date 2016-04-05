using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour
{
    public void LoadScene(int level)
    {
        //loadingImage.SetActive(true);
        Application.LoadLevel(level);

        //с LoadScene не работает :(
        //LoadScene(level);
    }

}
