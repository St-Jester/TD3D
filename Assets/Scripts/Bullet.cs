using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    private float damage;

    public float bulletSpeed = 50f;
    public float explosionRadius = 0f;

    public GameObject impactFX;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    public void Seek(Transform _target, float _damage)
    {
        damage = _damage;
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;

        //move towards it
        float distanceThisFrame = bulletSpeed * Time.deltaTime;
        if(dir.magnitude <= distanceThisFrame)//if true = we hit a target
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }
    void HitTarget()
    {
        GameObject FX = Instantiate(impactFX, transform.position, transform.rotation);
        Destroy(FX, 5f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);

        }
    }

    void Damage(Transform enemy)
    {
        Destroy(gameObject);
        enemy.GetComponent<Enemy>().KillingEnemies(this.damage);
        
    }
            
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, explosionRadius);
        foreach (var i in colliders)
        {
            if(i.tag == "Enemy")
            {
                Damage(i.transform);
            }
        }
    }
}
