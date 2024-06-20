using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBtnUI : MonoBehaviour
{
    public CharacterSO characterSO;

    public void SelectCharacter()
    {
        GameManager.Instance.curCharacter = characterSO;
    }
}
