using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour, IDamageable
{
    public float health = 100f;
    public TextManager textManager;


    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (textManager == null)
            {
                textManager = GameObject.FindObjectOfType<TextManager>();
            }

            textManager.UpdateScore(Random.Range(90, 140));
            GetComponent<EnemyMovement>().SetAlive(false);
            Destroy(gameObject);
        }
    }
}
