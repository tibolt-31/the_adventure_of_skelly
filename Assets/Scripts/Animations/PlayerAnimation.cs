using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation
{
    public Animator anim { get; set; }

    public PlayerAnimation(Animator anim)
    {
        this.anim = anim;
    }

    public void PlayHit()
    {
        anim.SetTrigger("Hit1");
    }

    public void PlayDeath()
    {
        anim.SetTrigger("Fall1");
    }

    public void PlayIsBlocking(bool isBlocking)
    {
        anim.SetBool("IsBlocking", isBlocking);
    }

    public void PlayRunHorizontal(float speed)
    {
        anim.SetFloat("speedh", speed);
    }

    public void PlayRunVertical(float speed)
    {
        anim.SetFloat("speedv", speed);
    }

    public void PlayAttack()
    {
        anim.SetTrigger("Attack1h1");
    }

    public void PlayIsPushing(bool isPushing)
    {
        anim.SetBool("IsPushing", isPushing);
    }
}
