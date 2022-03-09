using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerAlways : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Companion;
    public Transform player;
    void Update()
    {
        Companion.transform.LookAt(player);
    }
}
