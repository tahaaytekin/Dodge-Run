using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public ColourType myType;
    //
    public Transform firePointParent;
    public Rigidbody rbShootBall;
    //

    public static Player Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void Shoot(Vector3 targetPos)
    {
        GameObject spawnedObject = Instantiate(rbShootBall.gameObject, firePointParent.transform);
        spawnedObject.transform.parent = null;
        spawnedObject.transform.DOMove(targetPos, 0.2f).SetEase(Ease.Linear);
    }
}
