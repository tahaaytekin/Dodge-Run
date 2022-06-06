using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Finish : MonoBehaviour
{
    public Transform newCameraTarget;
    public Animator megaEnemyAnimator;
    public Rigidbody[] rbs;


    public GameObject megaEnemy;
    public MeshRenderer[] mesh;
    public Color[] colors;

    public Transform finalPoint;

    public static Finish Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        int c = 0;
        foreach (var item in mesh)
        {
            item.material.color = colors[c];
            c++;
        }


        foreach (var item in rbs)
        {
            item.isKinematic = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("final Point'e geldi");
            foreach (var item in Level.Instance.enemies)
            {
                item.StopFollow();
            }
            PlayerHareket pMove = other.GetComponentInParent<PlayerHareket>();
            pMove.verticalSpeed = 0;
            pMove.gameObject.transform.DOMove(finalPoint.position, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                print(GameManager.Intance.slider.value);
                ThrowEnemy();
                Invoke(nameof(DoRagdoll), 0.05f);
            });
        }
    }
    public void ThrowEnemy()
    {
        SmoothFollow.Instance.distance *= 2;
        SmoothFollow.Instance.height = 10;
        SmoothFollow.Instance.target = newCameraTarget.transform;
        if (GameManager.Intance.slider.value >= 0 && GameManager.Intance.slider.value < 0.1f)
        {
            megaEnemy.transform.DOJump(mesh[0].transform.position, 5f, 1, 1.5f);
        }
        else if (GameManager.Intance.slider.value >= 0.1f && GameManager.Intance.slider.value < 0.2f)
        {
            megaEnemy.transform.DOJump(mesh[1].transform.position, 5f, 1, 1.5f);
        }
        else if (GameManager.Intance.slider.value >= 0.2f && GameManager.Intance.slider.value < 0.3f)
        {
            megaEnemy.transform.DOJump(mesh[2].transform.position, 5f, 1, 2.5f);
        }
        else if (GameManager.Intance.slider.value >= 0.3f && GameManager.Intance.slider.value < 0.4f)
        {
            megaEnemy.transform.DOJump(mesh[3].transform.position, 5f, 1, 2.5f);
        }
        else if (GameManager.Intance.slider.value >= 0.4f && GameManager.Intance.slider.value < 0.5f)
        {
            megaEnemy.transform.DOJump(mesh[4].transform.position, 5f, 1, 3f);
        }
        else if (GameManager.Intance.slider.value >= 0.5f && GameManager.Intance.slider.value < 0.6f)
        {
            megaEnemy.transform.DOJump(mesh[5].transform.position, 5f, 1, 3f);
        }
        else if (GameManager.Intance.slider.value >= 0.6f && GameManager.Intance.slider.value < 0.7f)
        {
            megaEnemy.transform.DOJump(mesh[6].transform.position, 5f, 1, 3f);
        }
        else if (GameManager.Intance.slider.value >= 0.7f && GameManager.Intance.slider.value < 0.8f)
        {
            megaEnemy.transform.DOJump(mesh[7].transform.position, 5f, 1, 3f);
        }
        else if (GameManager.Intance.slider.value >= 0.8 && GameManager.Intance.slider.value < 0.9f)
        {
            megaEnemy.transform.DOJump(mesh[8].transform.position, 5f, 1, 3f);
        }
        else if (GameManager.Intance.slider.value >= 0.9f && GameManager.Intance.slider.value < 1f)
        {
            megaEnemy.transform.DOJump(mesh[9].transform.position, 5f, 1, 3f);
        }
        else if (GameManager.Intance.slider.value == 1)
        {
            megaEnemy.transform.DOJump(mesh[10].transform.position, 5f, 1, 3f);
        }
        GameManager.Intance.StartCoroutine(GameManager.Intance.TextDisplay());
    }
    public void DoRagdoll()
    {

        megaEnemyAnimator.enabled = false;
        foreach (var item in rbs)
        {
            item.isKinematic = false;
        }
    }
   
}
