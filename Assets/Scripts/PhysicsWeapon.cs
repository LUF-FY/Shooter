using UnityEngine;

public class PhysicsWeapon : MonoBehaviour
{
    [SerializeField] private PhysicsBullet bulletPrefab;
    [SerializeField] private GameObject fireBallSource;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("FireMouse");
            //GetComponentInParent<Animator>().SetTrigger("Attack");
            FireBullet();
        }
    }

    public void FireBullet()
    {
        PhysicsBullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.transform.LookAt(GetTargetPoint());
        Debug.Log("Fire");
    }

    Vector3 GetTargetPoint()
    {
        //ray to center of the screen
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return ray.GetPoint(100);
    }
}
