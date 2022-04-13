using System;
using UnityEngine;

public class Move : StateMachineBehaviour
{
    private Fighter _enemyFighter;
    private float _attakRadius;
    private float _speed;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyFighter = GetEnemyFighter(animator);
        _attakRadius = GetAttakRadius(animator);
        _speed = GetSpeed(animator);
    }
        
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {       
        if (_enemyFighter.IsDeath)
        {
            animator.SetBool("IsDetected", false);
        }
        else
        {
            float step =  _speed * Time.deltaTime;            
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, _enemyFighter.transform.position, step);
        
            if (Vector3.Distance(animator.transform.position, _enemyFighter.transform.position) < _attakRadius)
            {
                animator.SetBool("isAttak", true);
            }     
        }        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    private float GetAttakRadius(Animator animator)
    {
        return animator.GetComponent<Fighter>().FighterData.attakRadius;
    }  

    private Fighter GetEnemyFighter(Animator animator)
    {
        return animator.GetComponent<Fighter>().CurrentEnemy;
    }

    private float GetSpeed(Animator animator)
    {
        return animator.GetComponent<Fighter>().FighterData.speed;
    }

}
