using UnityEngine;

[CreateAssetMenu(fileName = "NarrativeSO", menuName = "Scriptable Objects/NarrativeSO")]
public class NarrativeSO : ScriptableObject
{
    [Multiline]
    public string description = "Enter object description here";
    public int staminaCost = 1;
}
