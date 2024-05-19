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
        else if (collision.CompareTag("Boss"))
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
        else if (collision.CompareTag("Boss"))
        {
            isTrigger = false;
        }
    }
}
