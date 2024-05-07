using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera battleCam;
    [SerializeField] private AudioSource shotSFX;
    private Animator anim;

    private void Start()
    {
        anim = GameObject.Find("Arm").GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ShootBullet();
        }      
    }

    public void ShootBullet()
    {
        Debug.Log("something ig");
        Quaternion bulletRotation = Quaternion.Euler(0, 0, 90) * transform.rotation;
        Instantiate(bulletPrefab, shootingPoint.position, bulletRotation);
        shotSFX.Play();
        anim.SetBool("throwing", true);
    }

    public void setThrowFalse()
    {
        anim.SetBool("throwing", false);
    }
}
