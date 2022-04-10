using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public int health = 3;
    public int damage = 1;
    public float moveSpeed;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, ShootCore.instance.transform.position);
        
        if(dist > attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, ShootCore.instance.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            ShootCore.instance.TakeDamage(damage);
            Destroy(gameObject);
        }
        transform.LookAt(ShootCore.instance.transform);
    }

    public void TakeDamage()
    {
        health--;
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
}
