using DG.Tweening;
using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ColourType { BLUE, PURPLE, RED, GREEN };
public class Item : MonoBehaviour
{
    public MeshRenderer mesh;

    public ColourType cType;
    private void Start()
    {
        StartColor();
    }
    public void StartColor()
    {
        if (cType == ColourType.BLUE)
        {
            mesh.material.color = GameManager.Intance.color[0];
        }
        else if (cType == ColourType.PURPLE)
        {
            mesh.material.color = GameManager.Intance.color[1];
        }
        else if (cType == ColourType.RED)
        {
            mesh.material.color = GameManager.Intance.color[2];
        }
        else if (cType == ColourType.GREEN)
        {
            mesh.material.color = GameManager.Intance.color[3];
        }
    }
    int colorRank;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player p = other.GetComponentInParent<Player>();
            p.ballCount++;
            DOTween.To(() => GameManager.Intance.slider.value, (a) => GameManager.Intance.slider.value = a, GameManager.Intance.bolunecekSayi, 0.2f).SetRelative().SetEase(Ease.Linear);
            if (cType == p.myType)
            {
                print("aynı renk aldın");
                if (cType == ColourType.BLUE)
                {
                    print("blue");
                    if (Player.Instance.mesh.materials[0].color != GameManager.Intance.color[0]) 
                    {
                        Player.Instance.mesh.materials[0].color = GameManager.Intance.color[0];
                    }
                  else  if (Player.Instance.mesh.materials[0].color == GameManager.Intance.color[0])
                    {
                        Player.Instance.mesh.materials[1].color = GameManager.Intance.color[0];
                    }
                    else if (Player.Instance.mesh.materials[1].color == GameManager.Intance.color[0])
                    {
                        print("blue2");
                        Player.Instance.mesh.materials[2].color = GameManager.Intance.color[0];
                    }
                }
            }
            else
            {
                ItemConditions();
            }
            gameObject.transform.DOScale(transform.localScale * 1.3f, 0.1f).SetEase(Ease.Linear).OnComplete(() =>
              {
                  gameObject.transform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.Linear).OnComplete(() =>
                  {
                      gameObject.SetActive(false);
                  });
              });

            MMVibrationManager.Haptic(HapticTypes.LightImpact, true, this);
            GameManager.Intance.audioSource.PlayOneShot(GameManager.Intance.itemSound);
        }
    }
    public void ItemConditions()
    {
        if (cType == ColourType.RED)
        {
            print("rede dönüş");
            GameManager.Intance.DoColour(GameManager.Intance.color[2], this);
        }
        else if (cType == ColourType.BLUE)
        {
            print("blue dönüş");
            GameManager.Intance.DoColour(GameManager.Intance.color[0], this);
        }
        else if (cType == ColourType.PURPLE)
        {
            print("purpleColor dönüş");
            GameManager.Intance.DoColour(GameManager.Intance.color[1], this);
        }
        else if (cType == ColourType.GREEN)
        {
            print("greenColor dönüş");
            GameManager.Intance.DoColour(GameManager.Intance.color[3], this);
        }
    }
}
