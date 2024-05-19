using UnityEngine;

public class MonsterDetector : MonoBehaviour
{
    [SerializeField] Monster monster;
    [SerializeField] Monster_Movement monster_Movement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall")) 
        {
            monster.gameObject.transform.localScale = new Vector3(monster.gameObject.transform.localScale.x * -1, monster.gameObject.transform.localScale.y, monster.gameObject.transform.localScale.z) ;
            monster_Movement.moveSpeed *= -1;
        }
    }
}
