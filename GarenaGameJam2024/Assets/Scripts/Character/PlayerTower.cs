using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTower : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public Transform target;
    public OrbBullet orbBullet;
    public int count = 5;
    void Update()
    {
        transform.position = target.position;
    }

    public void Shoot(Element.ElementType elementType,Stat stat)
    {
        if(count > 0)
        {
            count -= 1;
            countText.text = count.ToString();
        }
        else
        {
            return;
        }
        OrbBullet ob =  Instantiate(orbBullet.gameObject, transform.position, Quaternion.identity).GetComponent<OrbBullet>();
        ob.Setup(elementType, stat);
    }

    public void ShowElement(bool _active)
    {
        gameObject.SetActive(_active);
    }
}
