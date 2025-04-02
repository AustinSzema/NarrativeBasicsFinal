using UnityEngine;

[CreateAssetMenu(fileName = "NarrativeSO", menuName = "Scriptable Objects/NarrativeSO")]
public class NarrativeSO : ScriptableObject
{
    public int staminaCost = 1;
    [Multiline]
    public string description = "Enter object description here";

}
