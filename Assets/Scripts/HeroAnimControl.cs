using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimControl : MonoBehaviour
{
    private Animator animator;

    // Ссылка на дочерний объект с аниматором
    public GameObject childWithAnimator;

    private States State
    {
        get { return (States)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value);}
    }

    void Start()
    {
        if (childWithAnimator != null)
        {
            animator = childWithAnimator.GetComponent<Animator>();
        }
    }

    public void SetIdle()
    {
        State = States.Hero_idle;
    }

    public void SetWalk()
    {
        State = States.Hero_walk;
    }

    public void SetJump()
    {
        State = States.Hero_jump;
    }

    public void SetAttack()
    {
        State = States.Hero_attack;
    }
}

public enum States 
{
    Hero_idle,
    Hero_walk,
    Hero_jump,
    Hero_attack
}
