using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Finish : MonoBehaviour
{
    public Transform newCameraTarget,megaEnemyTarget;
    public Animator megaEnemyAnimator;
    public Rigidbody[] rbs;


    public GameObject megaEnemy,particle;
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
           // print("final Point'e geldi");
            foreach (var item in Level.Instance.enemies)
            {
                if (item != null) Destroy(item.gameObject);
            }
            PlayerHareket pMove = other.GetComponentInParent<PlayerHareket>();
            pMove.verticalSpeed = 0;
            pMove.gameObject.transform.DOMove(finalPoint.position, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
              //  print(GameManager.Intance.slider.value);
                ThrowEnemy();
                Invoke(nameof(DoRagdoll), 0.5f);
            });
        }
    }
    public void ThrowEnemy()
    {
        Player.Instance.Shoot(megaEnemyTarget.position, true);
       
        Invoke(nameof(SonVurus),0.49f);
        Invoke(nameof(CamFocus),0.5f);

        Invoke(nameof(SliderValueControl), 0.5f);
     
    }
    public void DoRagdoll()
    {

        megaEnemyAnimator.enabled = false;
        foreach (var item in rbs)
        {
            item.isKinematic = false;
        }
    }
    public void SonVurus()
    {
        Player.Instance.spawnedObject.SetActive(false);
        particle.SetActive(true);
       
    }
    public void CamFocus()
    {
        SmoothFollow.Instance.distance *= 2;
        SmoothFollow.Instance.height = 10;
        SmoothFollow.Instance.target = newCameraTarget.transform;
    }
   public void SliderValueControl()
    {
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
        Invoke(nameof(MegaMass), 3.05f);
    }
   
    public void MegaMass()
    {
        foreach (var item in rbs)
        {
            item.mass = 10000;
            item.isKinematic = true;
        }
        GameManager.Intance.StartCoroutine(GameManager.Intance.TextDisplay());
        Invoke(nameof(ConfettiExplode), 1.5f);
    }
    public void ConfettiExplode()
    {
        GameManager.Intance.confetti.SetActive(true);
        GM.Instance.StartCoroutine(GM.Instance.OpenWinPanel());

    }
   
}
