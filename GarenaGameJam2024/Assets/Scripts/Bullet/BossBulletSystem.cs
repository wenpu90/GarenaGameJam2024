using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletSystem : MonoBehaviour
{
    public BossBullet bulletPrefab;
    public float rotateSpeed = 3f;
    public float shootInterval = 1f;
    private float timer;
    private void OnEnable()
    {
     
    }

    private void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward);
        if(timer <= 0)
        {
            timer = shootInterval;
            Instantiate(bulletPrefab.gameObject, transform.position, transform.rotation);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
