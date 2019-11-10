using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation
{
    private readonly Animator anim;

    public EnemyAnimation(Animator anim)
    {
        this.anim = anim;
    }

    public void PlayHit()
    {
        anim.SetTrigger("Hit");
    }

    public void PlayRun(float speed)
    {
        anim.SetFloat("Speed", speed);
    }

    public void PlayAttack()
    {
        anim.SetTrigger("Attack");
    }

    public void PlayDeath() 
    {
        anim.SetTrigger("Death");
    }

    public void SetIsRunning(bool isRunning)
    {
        anim.SetBool("IsRunning", isRunning);
    }

    public void SetRunSpeed(float speed)
    {
        anim.SetFloat("Speed", speed);
    }
}
