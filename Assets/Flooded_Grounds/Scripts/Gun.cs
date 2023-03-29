using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private GunData gunData;
    [SerializeField] private Transform muzzle;
    float timeSinceLastShot;
    public TextManager textManager;
    public AudioClip audioSourceShot;
    public AudioClip audioSourceEmptyMag;
    public AudioClip audioSourceReload;
    private AudioSource audioSource;


    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += startReloading;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        Debug.DrawRay(muzzle.position, transform.forward * gunData.maxDistance, Color.red);
    }

    public void Shoot()
    {
        if (gunData.currentAmmo > 0 && CanShoot())
        {
            if (Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hit, gunData.maxDistance))
            {
                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                damageable?.TakeDamage(gunData.damage);
            }

            gunData.currentAmmo--;
            timeSinceLastShot = 0;
            textManager.UpdateAmmo(gunData.currentAmmo);
            audioSource.PlayOneShot(audioSourceShot);

        }

        if (gunData.currentAmmo <= 0)
        {
            audioSource.PlayOneShot(audioSourceEmptyMag);
        }
    }

    public void startReloading()
    {
        if (!gunData.reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;
        audioSource.PlayOneShot(audioSourceReload);
        yield return new WaitForSeconds(gunData.reloadTime);
        gunData.currentAmmo = gunData.magSize;
        textManager.UpdateAmmo(gunData.currentAmmo);
        gunData.reloading = false;
    }
}
