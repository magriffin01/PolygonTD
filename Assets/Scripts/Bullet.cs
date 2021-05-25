/*
# Name: Mark Griffin
# Student ID#: 2340502
# Chapman email: magriffin@chapman.edu
# Course Number and Section: 236-02
# Assignment: Final Project
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 5f;
    public float ExplosionRadius = 0f;
    public float SlowPercentage = 0f;
    public int Damage = 50;
    private Transform target;

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = target.position - transform.position;
        float distanceThisFrame = Speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    public void Chase(Transform target)
    {
        this.target = target;
    }

    private void HitTarget()
    {
        if (SlowPercentage > 0f)
        {
            Slow();
        }
        if (ExplosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            DealDamage(target);
        }

        Destroy(gameObject);
    }

    private void DealDamage(Transform enemy)
    {
        Enemy enemyGameObject = enemy.GetComponent<Enemy>();

        if (enemyGameObject != null)
        {
            enemyGameObject.TakeDamage(Damage);
        }
    }

    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                DealDamage(collider.transform);
            }
        }
    }

    private void Slow()
    {
        target.GetComponent<Enemy>().Slow(SlowPercentage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
