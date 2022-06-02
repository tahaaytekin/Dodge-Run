using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public GameObject spawnedObject;
    public SkinnedMeshRenderer mesh;
    public int colourRank;
    public int ballCount;
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
        print("atış yap");
        spawnedObject = Instantiate(rbShootBall.gameObject, firePointParent.transform);
        BallColourChange(spawnedObject);
        spawnedObject.transform.parent = null;
        spawnedObject.transform.DOMove(targetPos, 0.2f).SetEase(Ease.Linear);
    }
    public void BallColourChange(GameObject a)
    {
        if (myType == ColourType.BLUE)
        {
            a.GetComponent<MeshRenderer>().materials[0].color = Color.blue;
        }
        else if (myType == ColourType.RED)
        {
            a.GetComponent<MeshRenderer>().materials[0].color = Color.red;
        }
        else if (myType == ColourType.GREEN)
        {
            a.GetComponent<MeshRenderer>().materials[0].color = Color.green;
        }
        else if (myType == ColourType.PURPLE)
        {
            a.GetComponent<MeshRenderer>().materials[0].color = Color.grey;
        }
    }
}
