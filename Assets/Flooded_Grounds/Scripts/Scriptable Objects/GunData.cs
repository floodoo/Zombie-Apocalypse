using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapons/Gun ")]
public class GunData : ScriptableObject
{
    [Header("Info")]
    public string gunName;
    [Header("Shooting")]
    public float damage;
    public float maxDistance;
    [Header("Ammo")]
    public int currentAmmo;
    public int magSize;
    public float fireRate;
    public float reloadTime;
    [HideInInspector]
    public bool reloading;
}
