using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    [SerializeField] private float attackDelay = 1;
    [SerializeField] private float attackRange = 10;
    [SerializeField] private float bulletForse = 30; // FEEDBACK: Это можно потенциально в prefab пули закинуть. Но не обязательно сейчас.
    [SerializeField] private float bulletDamage = 1; // FEEDBACK: Это тоже можно потенциально в prefab пули закинуть.

    [SerializeField] private Transform[] firePoints;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private FindNearest findNearest;

    [SerializeField] private enum Weapon {Pistol, Shotgun, RocketLauncher }
    
    [Header("Rocket Laucher")]
    [SerializeField] private float splashDamage = 1;
    [SerializeField] private float splashRange = 0;

    private void Start()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackDelay);

        GameObject nearestTarget = findNearest.nearest;

        if (nearestTarget == null)
        {
            yield return null;
        }

        if (Vector3.Distance(transform.position, nearestTarget.transform.position) > attackRange)
        {
            yield return null;
        }

        switch (weapon)
        {
            case Weapon.Pistol:
                Pistol();
                break;
            case Weapon.Shotgun:
                ShotGun();
                break;
            case Weapon.RocketLauncher:
                RocketLauncher();
                break;
        }
        
        StartCoroutine(Attack());
    }

    private void Pistol()
    {
        Shoot(bulletDamage, bulletForse, firePoints[0]);
    }

    private void ShotGun()
    {
        for (var i = 0; i < firePoints.Length; i++)
        {
            Shoot(bulletDamage, bulletForse, firePoints[i]);
        }
    }

    private void RocketLauncher()
    {
        GameObject rocket = Shoot(splashDamage, bulletForse, firePoints[0]);
        rocket.GetComponent<Bullet>().splashRange = splashRange;
    }
    private GameObject Shoot(float damage, float forse, Transform firePoint)
    {        
        GameObject go = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.damage = damage;
        bullet.forse = forse;

        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * forse, ForceMode2D.Impulse); //Temporary solution

        //bullet.firePoint = firePoint;    // не передаёт значение при попытке передать Vector2 отправляет .zero Fix_it

        return (go);
    }
}
