using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float speed;
    public float desrtoyTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
  
    private void Start()
    {
        Invoke("DestroyAmmo", desrtoyTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if(hitInfo.collider !=null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyHP>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<PlayerHP>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
