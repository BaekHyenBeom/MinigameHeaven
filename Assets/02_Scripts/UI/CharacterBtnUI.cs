using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterBtnUI : MonoBehaviour
{
    public CharacterSO characterSO;
    public TextMeshProUGUI nameTxt;

    private void OnEnable()
    {
        nameTxt.text = characterSO.characterName;
    }

    public void SelectCharacter()
    {
        GameManager.Instance.curCharacter = characterSO;
        GameManager.Instance.CallCharacterDescUI();
        Debug.Log($"{characterSO.characterName}이(가) 선택되었습니다.");
    }
}
