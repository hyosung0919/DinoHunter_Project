using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int maxHealth = 3;
    private int currentHealth;

    private Transform player;

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            transform.position += dir * speed * Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (GameDataManager.Instance != null)
        {
            GameDataManager.Instance.data.gold += 10;
            GameDataManager.Instance.Save();

            // °ñµå UI °»½Å
            var ui = FindObjectOfType<GoldManager>();
            if (ui != null) ui.UpdateGoldText();
        }

        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Player player = collision.collider.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(1);
            }
        }
        Destroy(gameObject);
    }
}
