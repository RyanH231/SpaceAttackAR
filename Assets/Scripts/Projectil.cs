using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyShip enemy = other.GetComponent<EnemyShip>();
        if(enemy != null)
        {
            enemy.TakeDamage();
            Destroy(gameObject);

        }
    }
}
