using System;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public Action<Fighter> OnDefeat;
    public FighterData FighterData { get => _fighterData; }
    public Fighter CurrentEnemy { get => _currentEnemy; }
    public bool IsDeath { get => _isDeath; }
    public Health Health { get => _health; }

    [SerializeField] private FighterData _fighterData;

    private Animator _stateMashine;
    private Health _health;
    private Fighter _currentEnemy;
    private bool _isDeath;
       
    private void Awake()
    {
        _stateMashine = GetComponent<Animator>();
        _health = GetComponent<Health>();
        _health.Init(_fighterData.health);
    }

    private void OnEnable()
    {
        _health.HealthChanged += ChekIsDead;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ChekIsDead;
    }

    public void SetCurrentEnemy(Fighter currentEnemy)
    {
        _currentEnemy = currentEnemy;
    }

    private void ChekIsDead()
    {
        if (_health.Current <= 0)
        { 
            _isDeath = true;
            OnDefeat?.Invoke(this);
            _stateMashine.SetTrigger("Death");            
        }        
    }
}

