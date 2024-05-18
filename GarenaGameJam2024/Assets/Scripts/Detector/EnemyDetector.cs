using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public bool isTrigger = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isTrigger = false;
        }
    }
}
