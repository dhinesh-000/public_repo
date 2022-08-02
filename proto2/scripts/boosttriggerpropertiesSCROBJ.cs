using UnityEngine;

[CreateAssetMenu(menuName ="SCROBJ/Prefab/BOOSTTRIGGER")]
///...proto2...///
public class boosttriggerpropertiesSCROBJ : ScriptableObject
{
    [Tooltip("time for the boost to last")]
    public float decreaseovertime;
    [Tooltip("rate at which it decreases to zero/0")]
    public float rate;
}
