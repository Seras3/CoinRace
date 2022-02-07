using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Walk(bool move) 
    {
        animator.SetBool(AnimationTags.MOVEMENT, move);
    }
    
    public void Punch1() 
    {
        animator.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
    }
    
    public void Punch2() 
    {
        animator.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
    }
    
    public void Punch3() 
    {
        animator.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
    }
    
    public void Kick1()
    {
        animator.SetTrigger(AnimationTags.KICK_1_TRIGGER);
    }
    
    public void Kick2()
    {
        animator.SetTrigger(AnimationTags.KICK_2_TRIGGER);
    }

    public void Hit()
    {
        animator.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void KnockDown()
    {
        animator.SetTrigger(AnimationTags.KNOCK_DOWN_TRIGGER);
    }

    public void GetUp()
    {
        animator.SetTrigger(AnimationTags.GET_UP_TRIGGER);
    }
    
    public void Death()
    {
        animator.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }
}
