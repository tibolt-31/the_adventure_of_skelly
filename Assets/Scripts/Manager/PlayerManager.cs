using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject Player;
    public GameObject Weapon;

    public PlayerCombat PlayerCombat;
    public float AttackTimer;

    private void Start()
    {
        PlayerCombat = Weapon.GetComponent<PlayerCombat>();
    }

    private void Update()
    {
        AttackTimer = Player.GetComponent<PlayerController>().GetTimeAttack();
    }
}
