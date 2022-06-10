using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum GateType { BLUE, PURPLE, RED, GREEN };
public class Gate : MonoBehaviour
{
    public GateType myGate;
    public MeshRenderer planeObject;
    public Color blueMaterial, purpleMaterial, redMaterial, greenMaterial;
    private void Start()
    {
        StartColorChange();
    }
    public void StartColorChange()
    {
        if (myGate == GateType.BLUE)
        {
            planeObject.materials[0].color = blueMaterial;
        }
        else if (myGate == GateType.PURPLE)
        {
            planeObject.materials[0].color = purpleMaterial;
        }
        else if (myGate == GateType.RED)
        {
            planeObject.materials[0].color = redMaterial;
        }
        else if (myGate == GateType.GREEN)
        {
            planeObject.materials[0].color = greenMaterial;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //  print("gate'e girdi");
            Player p = other.GetComponentInParent<Player>();
            CharacterColorChanges(other);
            MMVibrationManager.Haptic(HapticTypes.LightImpact, true, this);
            GameManager.Intance.audioSource.PlayOneShot(GameManager.Intance.gateSound);
            gameObject.SetActive(false);

        }
    }
    public void CharacterColorChanges(Collider other)
    {
        if (myGate == GateType.BLUE)
        {
            Player.Instance.myType = ColourType.BLUE;
            GameManager.Intance.oldType = ColourType.BLUE;
            Player.Instance.mesh.materials[0].color = GameManager.Intance.color[0];
            Player.Instance.mesh.materials[1].color = GameManager.Intance.color[0];
            Player.Instance.mesh.materials[2].color = GameManager.Intance.color[0];
        }
        else if (myGate == GateType.PURPLE)
        {
            Player.Instance.myType = ColourType.PURPLE;
            GameManager.Intance.oldType = ColourType.PURPLE;
            Player.Instance.mesh.materials[0].color = GameManager.Intance.color[1];
            Player.Instance.mesh.materials[1].color = GameManager.Intance.color[1];
            Player.Instance.mesh.materials[2].color = GameManager.Intance.color[1];
        }
        else if (myGate == GateType.RED)
        {
            Player.Instance.myType = ColourType.RED;
            GameManager.Intance.oldType = ColourType.RED;
            Player.Instance.mesh.materials[0].color = GameManager.Intance.color[2];
            Player.Instance.mesh.materials[1].color = GameManager.Intance.color[2];
            Player.Instance.mesh.materials[2].color = GameManager.Intance.color[2];
        }
        else if (myGate == GateType.GREEN)
        {
            Player.Instance.myType = ColourType.GREEN;
            GameManager.Intance.oldType = ColourType.GREEN;
            Player.Instance.mesh.materials[0].color = GameManager.Intance.color[3];
            Player.Instance.mesh.materials[1].color = GameManager.Intance.color[3];
            Player.Instance.mesh.materials[2].color = GameManager.Intance.color[3];
        }
    }
}
