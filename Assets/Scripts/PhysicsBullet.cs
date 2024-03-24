using UnityEngine;

public class PhysicsBullet : MonoBehaviour
{
    [SerializeField] float _speed = 50;
    [SerializeField] float damage = 10;
    void Start()
    {
        Destroy(gameObject, 5);
        GetComponent<Rigidbody>().velocity = transform.forward * _speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
