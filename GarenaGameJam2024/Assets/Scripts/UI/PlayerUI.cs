using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Player player;
    public Image hp;

    public TextMeshProUGUI fire;
    public TextMeshProUGUI water;
    public TextMeshProUGUI wood;

    public void UpdateHealth(float _health)
    {
        hp.DOFillAmount(_health, 0.5f);
    }

    public void UpdateElement(Player player)
    {
        fire.text = $"{player.stat.attack}";
        water.text = $"{player.stat.health}";
        wood.text = $"{player.stat.movementSpeed}";
    }
}
