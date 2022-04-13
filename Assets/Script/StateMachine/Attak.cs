using UnityEngine;

public class Attak : StateMachineBehaviour
{
    private Fighter _enemyFighter;
    private float _rateFire;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyFighter = GetEnemyFighter(animator);
        _rateFire = GetRateFire(animator);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_enemyFighter.IsDeath)
        { 
            _enemyFighter.Health.TakeDamage(_rateFire);
        }
        else
        {
            animator.SetBool("IsDetected", false);  
            animator.SetBool("isAttak", false);  
        }        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    private Fighter GetEnemyFighter(Animator animator)
    {
        return animator.GetComponent<Fighter>().CurrentEnemy;
    }

    private float GetRateFire(Animator animator)
    {
        return animator.GetComponent<Fighter>().FighterData.rateFire;
    }
}
