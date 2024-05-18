using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    private void FixedUpdate()
    {
        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
