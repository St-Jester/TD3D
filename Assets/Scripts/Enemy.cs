using System;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

    public delegate void Killing();
    public static event Killing KillEvent;

    public float speed = 10f;

    public float health = 10f;
    
    public void KillingEnemies(float damage)
    {
        health -= damage;
        //subtract damage from health;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }       
    }
    private void OnDestroy()
    {
        
        if (KillEvent != null)
        {
            KillEvent.Invoke();//firing an event
            //Debug.Log("On destroyed");
        }
    }
    
}
