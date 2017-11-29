using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    [Header("Turret features")]
    public float range = 15f;
    public float fireRate = 2f;
    public float damage = 3f;
    public GameObject bulletPrefab;
    public Transform firepoint;

    [Header("Setup things")]
    public Transform rotationPart;
    public float turnSpeed = 6f;
    public string enemyTag = "Enemy";
    
    
    private Transform target;

    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        
            InvokeRepeating("Shoot", 0f, 1f / fireRate);
    }

    void Update() {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(rotationPart.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;
        rotationPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy!= null && shortestDistance <=range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void Shoot()
    {
        if (target != null)
        {
            //Debug.Log("Shooting at " + target.name);
            GameObject BulletObj =  Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Bullet bullet = BulletObj.GetComponent<Bullet>();
            if (bullet != null)
                bullet.Seek(target);

            target.GetComponent<Enemy>().KillingEnemies(this.damage);
            
        }
    }
}
