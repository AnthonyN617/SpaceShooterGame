using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject enemyDeath;
    public GameObject missileExplosion;
    public LayerMask mask;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 2.0f, mask);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i] != null) ;
            {
                Instantiate(enemyDeath, hitColliders[i].transform.position, Quaternion.identity);
                Destroy(hitColliders[i].gameObject);
            }


            Instantiate(missileExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (gameObject.tag == "barrier")
        {

        }
    }
}