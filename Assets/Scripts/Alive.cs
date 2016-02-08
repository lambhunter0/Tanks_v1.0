using UnityEngine;
using System.Collections;

public class Alive : MonoBehaviour, Damageable {

    public float totalHealth;
    protected float health;
    protected bool dead;

    public event System.Action onDeath;

    public void TakeHit(float damage, RaycastHit hit)
    {
        health -= damage;

        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    protected void Die()
    {
        dead = true;
        if (onDeath != null)
        {
            onDeath();
        }
        GameObject.Destroy(gameObject);
    }

    protected virtual void Start()
    {
        health = totalHealth;
    }
}
