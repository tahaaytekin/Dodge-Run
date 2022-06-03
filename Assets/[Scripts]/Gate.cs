using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("gate'e girdi");
            Player p = other.GetComponentInParent<Player>();
            p.myType = ColourType.BLUE;
            GameManager.Intance.oldType = ColourType.BLUE;
            Player.Instance.mesh.materials[0].color = GameManager.Intance.color[0];
            Player.Instance.mesh.materials[1].color = GameManager.Intance.color[0];
            Player.Instance.mesh.materials[2].color = GameManager.Intance.color[0];
            MMVibrationManager.Haptic(HapticTypes.LightImpact, true, this);
            GameManager.Intance.audioSource.PlayOneShot(GameManager.Intance.gateSound);
            gameObject.transform.DOScale(Vector3.zero, 0.15f).SetEase(Ease.Linear).OnComplete(()=> 
            {
                gameObject.SetActive(false);
            });
        }
    }
}
