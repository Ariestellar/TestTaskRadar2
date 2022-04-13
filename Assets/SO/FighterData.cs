using UnityEngine;

[CreateAssetMenu(fileName = "FighterData", menuName = "FighterData")]
public class FighterData : ScriptableObject
{
    public ColorTeam colorTeam;
    public float health;
    public float speed;
    public float viewRadius;
    public float attakRadius;
    public float rateFire;
}

public enum ColorTeam
{ 
    Red,
    Blue
}

