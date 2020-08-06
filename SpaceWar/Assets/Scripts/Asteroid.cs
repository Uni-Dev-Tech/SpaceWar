using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
     [SerializeField]
    private float asteroidSpeed = 50;
    public ParticleSystem explosion;
    private MeshRenderer meshRender;
    public bool doublePlay = false;
    public float speedRotation;
    void FixedUpdate()
    {
        transform.Translate(0, 0, -asteroidSpeed * Time.fixedDeltaTime);
        transform.Rotate(0, 0, speedRotation);
        if (transform.position.z < -120)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !doublePlay ||
            other.CompareTag("Bullet") && !doublePlay)
        {
            if (other.CompareTag("Player"))
            {
                PlayerController.shipLives -= 1f;
                Destroy(UIManager.instance.hearts[UIManager.instance.index]);
                UIManager.instance.index += 1;
            }
            if(other.CompareTag("Bullet"))
            {
                PlayManager.instance.asteroidScore++;
            }
            doublePlay = true;
            explosion.Play();
            SoundManager.instance.explosionSound.Play();
            meshRender = GetComponent<MeshRenderer>();
            meshRender.enabled = false;
        }
    }
}
