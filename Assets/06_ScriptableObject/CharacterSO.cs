using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "SO/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public string characterName;
    public GameObject playerPrefab;
    public Sprite characterSprite;
    public List<Animator> characterAnimator;
}
