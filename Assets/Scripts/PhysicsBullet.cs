using UnityEngine;

public class PhysicsBullet : MonoBehaviour
{
    [SerializeField] float _speed = 50;
    void Start()
    {
        Destroy(gameObject, 5);
        GetComponent<Rigidbody>().velocity = transform.forward * _speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy_W6>() != null)
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
