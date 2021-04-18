using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hero", menuName = "Hero")]
public class ClassSO : ScriptableObject
{
    [SerializeField]
    public string ClassName;
    [SerializeField]
    public int BaseHP;
    [SerializeField]
    public int BaseDeckSize;
    [SerializeField]
    public int BaseHandSize;
    [SerializeField]
    public int BaseStamina;

}
