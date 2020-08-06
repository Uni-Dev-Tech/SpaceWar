using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 70f;
    void FixedUpdate()
    {
        transform.Translate(0, 0, bulletSpeed * Time.fixedDeltaTime);
        if (transform.position.z > 90)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
            if(other.GetComponent<MeshRenderer>().enabled)
                Invoke("DestroyBullet", 0.1f);
    }
    private void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
