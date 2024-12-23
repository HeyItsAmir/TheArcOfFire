using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeWeapon : weapon
{
    [SerializeField] aimComponet AimCom;
    [SerializeField] float damage = 10f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float bulletLifetime = 5f; 

    public override void Attack()
    {
        GameObject target = AimCom.GetAim(out Vector3 aimDir);

        DamageObject(target, damage);

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            //float bulletForce = 10f;
            //bulletRigidbody.AddForce(aimDir * bulletForce, ForceMode.Impulse);
        }

        
        Destroy(bullet, bulletLifetime);
    }

    // ...
}
