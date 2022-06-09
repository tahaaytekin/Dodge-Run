using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Level : MonoBehaviour
{
    public NavMeshSurface surface;
    public Enemy[] enemies;
    public static Level Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        surface = GetComponent<NavMeshSurface>();
        surface.BuildNavMesh();
    }
}
