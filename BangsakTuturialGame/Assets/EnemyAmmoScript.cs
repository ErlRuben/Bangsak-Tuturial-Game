using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmoScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    void Start()
    {
        Destroy(bullet, 10);
    }
}
