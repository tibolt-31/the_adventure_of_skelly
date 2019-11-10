using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCombat : MonoBehaviour
{
    public CharacterStats characterStats;
    public float hitTimer = 0f;
    public float attackTimeFrequency = 1.5f;
    public bool isDead = false;
    public ParticleSystem deathParticle;

    public GameObject enemyMeshRef;
    public GameObject enemyRef;

    private Transform target;
    private NavMeshAgent agent;
    private EnemyAnimation enemyAnimation;

    private float attackTimer = 0f;
    private IEnumerator deathCor;
    private IEnumerator hitCor;
    private Rigidbody rb;

    private void Start()
    {
        target = PlayerManager.instance.Player.transform;
        agent = enemyRef.GetComponent<NavMeshAgent>();
        EnemyManager.instance.listEnemyCombat.Add(this);
        enemyAnimation = new EnemyAnimation(enemyRef.GetComponent<Animator>());
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= agent.stoppingDistance)
        {
            attackTimer += Time.deltaTime;
        }
        else
        {
            attackTimer = 0;
        }

        if (distance <= agent.stoppingDistance && attackTimer > attackTimeFrequency && !isDead)
        {
            DoDamageToPlayer();
            enemyAnimation.PlayAttack();
            attackTimer = 0f;
        }

        enemyAnimation.SetRunSpeed(!(agent.velocity.x == 0 && agent.velocity.y == 0 && agent.velocity.z == 0) ? 1f : 0f);
        hitTimer += Time.deltaTime;
        rb.position = transform.position;
    }

    public void TakeDamage(float damage)
    {
        if (hitTimer > 0.8f)
        {
            characterStats.currentHealth -= damage;
            hitTimer = 0f;
            enemyAnimation.PlayHit();
            hitCor = OnHit();
            StartCoroutine(hitCor);
        }

        if (characterStats.currentHealth <= 0 && !isDead)
        {
            isDead = true;
            deathCor = OnDeath();
            enemyAnimation.PlayDeath();
            StartCoroutine(deathCor);
        }
    }

    private void DoDamageToPlayer()
    {
        PlayerManager.instance.PlayerCombat.TakeDamage(characterStats.damage, transform.position);
        
    }

    private IEnumerator OnDeath()
    {
        enemyRef.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(2f);
        enemyMeshRef.GetComponent<SkinnedMeshRenderer>().enabled = false;
        deathParticle.Play();
        StartCoroutine(DestroyEnemy());
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }

    private IEnumerator OnHit()
    {
        yield return new WaitForSeconds(0.4f);
        agent.speed = characterStats.speed;
    }

    private void OnDestroy()
    {
        EnemyManager.instance.listEnemyCombat.Remove(this);
    }
}
