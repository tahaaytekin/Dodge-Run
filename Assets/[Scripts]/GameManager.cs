﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shootSound;
    public static GameManager Intance;
    private void Awake()
    {
        Intance = this;
    }
}
