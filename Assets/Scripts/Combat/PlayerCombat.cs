using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public CharacterStats playerStats;
    public ParticleSystem swordHit;
    public bool isBlocking = false;
    
    private PlayerAnimation playerAnimation;

    // callback

    public void Start()
    {
        playerAnimation = new PlayerAnimation(PlayerManager.instance.Player.GetComponent<Animator>());
        playerStats.currentHealth = GameManager.playerHealth;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            isBlocking = true;
        }
        else
        {
            isBlocking = false;
        }

        playerAnimation.PlayIsBlocking(isBlocking);
    }

    public void TakeDamage(float damage, Vector3 enemyPos)
    {        
        Vector3 enemyDir = enemyPos - PlayerManager.instance.Player.transform.position;
        float angle = Vector3.Angle(PlayerManager.instance.Player.transform.forward, enemyDir);
        
        if (isBlocking && angle < 90f)
        {
            SoundManager.Instance.PlayBlock();
            return;
        }
        playerStats.currentHealth -= 1;
        GameManager.playerHealth -= 1;
        if (playerStats.currentHealth < 0)
        {
            playerAnimation.PlayDeath();
        }
        else
        {
            playerAnimation.PlayHit();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        OnDetectCollision(col);
    }

    private void OnDetectCollision(Collision col)
    {
        if (col.gameObject.tag == "Enemy" && PlayerManager.instance.AttackTimer < 0.4f)
        {
            Attack(col);
        }

        if (col.gameObject.tag == "RoomTP")
        {
            GameManager.playerHealth = playerStats.currentHealth;
            SceneManager.LoadScene(col.gameObject.name.Substring(3));
        }
    }

    private void Attack(Collision col)
    {
        var enemyFound = EnemyManager.instance.listEnemyCombat.Find(enemy => enemy.name == col.gameObject.name);
        if (enemyFound.hitTimer < 0.5f)
            return;
        enemyFound.TakeDamage(playerStats.damage);
        swordHit.Play();
    }

   
    public void Heal(float amount)
    {
        playerStats.currentHealth += Mathf.Clamp(amount, 0, playerStats.maxHealth);
    }
}
