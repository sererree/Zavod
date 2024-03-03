using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Bullet bulletPrefab;
    //public Transform bulletSourceTransform;
     private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }
    void FireBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.transform.LookAt(GetTargetPoint());
    }

    Vector3 GetTargetPoint ()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            return hit.point;
        }
        return ray.GetPoint(100);
    }
}
