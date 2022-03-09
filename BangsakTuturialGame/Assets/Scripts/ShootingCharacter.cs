using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCharacter : MonoBehaviour
{
    public GameObject projectile;
    public GameObject bulletspawn;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Rigidbody rb = Instantiate(projectile, bulletspawn.transform.position,  bulletspawn.transform.rotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 1f, ForceMode.Impulse);
        }
    }
}
