using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject bullet;
    void Start()
    {
        Destroy(bullet, 10);
    }
}
