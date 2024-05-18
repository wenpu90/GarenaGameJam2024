using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float bulletSpeed;
    private void FixedUpdate()
    {
        transform.Translate(transform.right * bulletSpeed * Time.deltaTime);
    }
}
