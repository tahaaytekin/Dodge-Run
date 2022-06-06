using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Enemy[] enemies;
    public static Level Instance;
    private void Awake()
    {
        Instance = this;
    }

}
