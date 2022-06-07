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
    public void Shoot(Vector3 targetPos, bool shootState)
    {
     //   print("atış yap");
        if (ballCount > 0 || shootState)
        {
            PlayerHareket.Instance.playerAnimator.SetTrigger("Throw");
            StartCoroutine(DoShoot(targetPos));
        }
    }
    public IEnumerator DoShoot(Vector3 targetPos)
    {
        yield return new WaitForSeconds(0.3f);
        spawnedObject = Instantiate(rbShootBall.gameObject, firePointParent.transform);
        BallColourChange(spawnedObject);
        spawnedObject.transform.parent = null;
        spawnedObject.transform.DOMove(targetPos, 0.2f).SetEase(Ease.Linear);
        ballCount--;
        DOTween.To(() => GameManager.Intance.slider.value, (a) => GameManager.Intance.slider.value = a, -GameManager.Intance.bolunecekSayi, 0.2f).SetRelative().SetEase(Ease.Linear);

    }
    public void BallColourChange(GameObject a)
    {
        if (myType == ColourType.BLUE)
        {
            a.GetComponent<MeshRenderer>().materials[0].color = GameManager.Intance.color[0];
        }
        else if (myType == ColourType.RED)
        {
            a.GetComponent<MeshRenderer>().materials[0].color = GameManager.Intance.color[2];
        }
        else if (myType == ColourType.GREEN)
        {
            a.GetComponent<MeshRenderer>().materials[0].color = GameManager.Intance.color[3];
        }
        else if (myType == ColourType.PURPLE)
        {
            a.GetComponent<MeshRenderer>().materials[0].color = GameManager.Intance.color[1];
        }
    }
}
