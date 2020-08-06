using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController playerController;
    private Animator playerAnimation;
    [SerializeField]
    private float engineForce = 50f;
    [SerializeField]
    private float minHorizontalPosition = -47f, maxHorizontalPosition = 47f;
    [SerializeField]
    private float minVerticalPosition = -64f, maxVerticalPosition = 84f;
    private Vector3 shipMothion;
    public GameObject bullet;
    public Transform firePoint;
    private bool reload = true;
    static public float shipLives;
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        playerAnimation = GetComponent<Animator>();
        shipLives = 3f;
    }
    void Update()
    {
        if (shipLives < 1f) Destroy(this.gameObject);

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        // Ограничивает передвижение (за интерфейс)
        if (transform.position.x >= maxHorizontalPosition)
            if (horizontalMove > 0)
                horizontalMove *= 0;
        if (transform.position.x <= minHorizontalPosition)
            if (horizontalMove < 0)
                horizontalMove *= 0;
        if (transform.position.z >= maxVerticalPosition)
            if (verticalMove > 0)
                verticalMove *= 0;
        if (transform.position.z <= minVerticalPosition)
            if (verticalMove < 0)
                verticalMove *= 0;

        shipMothion = (Vector3.right * horizontalMove + Vector3.forward * verticalMove + Vector3.up * 0) * engineForce;

        playerAnimation.SetFloat("horizontalDirection", horizontalMove);
        playerAnimation.SetFloat("verticalDirection", verticalMove);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            if(reload && Time.timeScale != 0)
            {
                reload = false;
                Fire();
                Invoke("Reload", 1f);
            }
    }
    private void FixedUpdate()
    {
        playerController.Move(shipMothion * Time.fixedDeltaTime);
    }
    /// <summary>
    /// Метод выстрела
    /// </summary>
    private void Fire()
    {
        Instantiate(bullet, firePoint.position, Quaternion.identity);
        SoundManager.instance.lazerSound.Play();
    }
    /// <summary>
    /// Метод для задержки следующего выстрела
    /// </summary>
    private void Reload()
    {
        reload = true;
    }
}
