using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject particle;
    public float forceGuc;
    public Rigidbody hipsRb;
    public CapsuleCollider meshCapsuleCollider;
    public Rigidbody[] rbs;
    public Animator enemyAnimator;
    private float lastTime;
    private bool isDone;
    public Transform targetPoint;
    private void Start()
    {
        foreach (var item in rbs)
        {
            item.isKinematic = true;
        }
    }
    void Update()
    {
        transform.LookAt(Player.Instance.transform.position);
        if (Time.time > lastTime + 0.01f)
        {
            lastTime = Time.time;
            if (transform.position.z - Player.Instance.transform.position.z < 10f && transform.position.z - Player.Instance.transform.position.z > 0)
            {
                if (!isDone)
                {
                    isDone = true;
                    //   print("player vuracak");
                    if (Player.Instance.ballCount > 0) Player.Instance.Shoot(targetPoint.transform.position);
                }

            }
            else if (transform.position.z - Player.Instance.transform.position.z <= 0f)
            {
                if (!isDone)
                {
                    isDone = true;
                    //  print("kovalayacak");
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("shootBall"))
        {
            //print("if'e girdi");
            collision.gameObject.tag = "Untagged";
            //collision.gameObject.SetActive(false);
            meshCapsuleCollider.enabled = false;
            DoRagdoll();
            hipsRb.AddForce(Vector3.forward * forceGuc, ForceMode.Impulse);
            MMVibrationManager.Haptic(HapticTypes.LightImpact, true, this);
            particle.SetActive(true);
            GameManager.Intance.audioSource.PlayOneShot(GameManager.Intance.shootSound);
        }
    }
    public void DoRagdoll()
    {

        enemyAnimator.enabled = false;
        foreach (var item in rbs)
        {
            item.isKinematic = false;
        }
    }
}
