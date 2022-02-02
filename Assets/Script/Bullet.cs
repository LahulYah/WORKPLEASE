using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public GameObject impactEffect;
    public float speed = 70f;
    public int damage = 50;
    public float explosionRadius = 0f;
    public AudioSource audioSource;
    public AudioClip sound;

    public void Seek(Transform _target)
    {

        target = _target;

    }

    //Si la balle attein la cible, detruit la balle
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;


        // permet de savoir si il y'a encore une distance entre la target et la balle si c'est pas le cas, lance HitTarget
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;

        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }
    //Cree les particles sur l'object quand la balle touche, detruit la target, detruit la balle et au bout de 2sec detruit les particles
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(sound, transform.position);
        Destroy(effectIns, 3f);

        if(explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        
        Destroy(gameObject);
    }

    // Fait spawn un raduis a la position pour connaitre les collider dedant et donc imfliger des degats aux enemy dedant
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            Debug.Log("Degat");
            e.TakeDamage(damage);
        }
        else
        {
            Debug.Log("Pas de script enemy fait gaffe ta merdé");
        }

        e.TakeDamage(damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
