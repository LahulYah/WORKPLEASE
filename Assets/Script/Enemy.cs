using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int health = 100;
    public int value = 20;
    public GameObject deathEffect;
    private Transform target;
    private int waypointIndex = 0;

    public AudioSource audioSource;
    public AudioClip sound;


    //Je fait une liste qui enregistre mes waypoint, qui permet aux enemis de suivre un chemain que j'ai definie avec ceux-ci
    private void Start()
    {
        target = Waypoints.points[0];
    }
    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        GameObject deathParticles = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(deathParticles, 2f);
        PlayerStats.money += value;

    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
    private void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);

    }
}
