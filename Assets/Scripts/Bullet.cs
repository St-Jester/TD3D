using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float bulletSpeed = 50f;

    public GameObject impactFX;

    public void Seek(Transform _target)
    {
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
    }
    void HitTarget()
    {
        GameObject FX = Instantiate(impactFX, transform.position, transform.rotation);
        Destroy(FX, 2f);
        Destroy(gameObject);
        //Debug.Log("HIT");
    }
}
