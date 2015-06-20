using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerStats))]
public class PlayerBehaviour : MonoBehaviour
{
    public GameObject SmokeSplosion;

    private PlayerStats stats;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (transform.position.y < -10)
            Die();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            stats.RemoveHealth(10f);
        }
    }

    public void Die()
    {
        stats.CurrentHealth = stats.MaxHealth;

        transform.position = new Vector3(Random.Range(-150, 150), 10, Random.Range(-150, 150));
    }

    public void Attack()
    {
        
    }
}
