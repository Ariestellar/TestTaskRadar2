using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Fighter[] _fighter;
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private TextMeshProUGUI _timer;

    private DateTime _startTime;
    private DateTime _endTime;

    private int _countDefeatFighterBlue;
    private int _countDefeatFighterRed;

    public void LaunchFight()
    {
        _startPanel.SetActive(false);
        _startTime = DateTime.Now;
        for (int i = 0; i < _fighter.Length; i++)
        {
            _fighter[i].GetComponent<Animator>().enabled = true;
            _fighter[i].OnDefeat += ChekVictory;
        }
    }

    private void ChekVictory(Fighter defeatFighter)
    {
        if (defeatFighter.FighterData.colorTeam == ColorTeam.Blue)
        {
            _countDefeatFighterBlue += 1;
        }
        else
        {
           _countDefeatFighterRed += 1;
        }

        if (_countDefeatFighterBlue == 3 || _countDefeatFighterRed == 3)
        {
            _endTime = DateTime.Now;
            _victoryPanel.SetActive(true);
            TimeSpan result = _endTime.Subtract(_startTime);            
            _timer.text = result.TotalSeconds.ToString();
        }
    }
}
