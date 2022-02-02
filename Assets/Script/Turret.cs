using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    public float range = 15f;

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    private float turnSpeed = 6f;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoints;

    public AudioSource audioSource;
    public AudioClip sound;

    // Invoke une fonction qui va ce repeter
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Cherche une cible avec le tag "Enemy" le plus proche de lui et le "Suis du regard"
    void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in ennemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {

                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null; 

        }
    }

    //Si aucune cible n'est trouver, on applique pas. Si non, on suis la target du regard
    // Avec un calculue pour modifier le firerate
    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1 / fireRate;
        }
        
        fireCountdown -= Time.deltaTime;
    }

    // fonction de tire qui prend on fonction la recherche de cible du script "bullet"
    void Shoot()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoints.position, firePoints.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {

            bullet.Seek(target);
        }
    }

    //Crée un gizmos qui me permet de voir la porter de la tour (Je le met en rouge c'est plus visible)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
