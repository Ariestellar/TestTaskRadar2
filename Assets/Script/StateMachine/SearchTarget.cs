using UnityEngine;

public class SearchTarget : StateMachineBehaviour
{
    private float _viewRadius;    
    private ColorTeam _enemyTeam;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _viewRadius = GetViewRadius(animator);
        _enemyTeam = GetColorEnemyTeam(animator);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (var item in Physics.OverlapSphere(animator.transform.position, _viewRadius))
        {         
            if (item.GetComponent<Fighter>().FighterData.colorTeam == _enemyTeam)
            {                
                animator.GetComponent<Fighter>().SetCurrentEnemy(item.GetComponent<Fighter>());
                animator.SetBool("IsDetected", true);                
            }
        }        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    private float GetViewRadius(Animator animator)
    {
        return animator.GetComponent<Fighter>().FighterData.viewRadius;
    }    

    private ColorTeam GetColorEnemyTeam(Animator animator)
    {
        return animator.GetComponent<Fighter>().FighterData.colorTeam == ColorTeam.Red ?  ColorTeam.Blue: ColorTeam.Red;
    }   
}
