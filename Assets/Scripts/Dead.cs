using UnityEngine;
using System.Collections;

public interface IDead
{
    void Dead(string message, params object[] parametrs);
}
